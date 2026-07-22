using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manisai_WEB_MVC.Models;
using BCrypt.Net;

namespace Manisai_WEB_MVC.Controllers
{
    public class StudentmastersController : Controller
    {
        private readonly LmsContext _context;

        public StudentmastersController(LmsContext context)
        {
            _context = context;
        }

        // GET: Studentmasters
        public async Task<IActionResult> Index()
        {
            var lmsContext = _context.Studentmasters.Include(s => s.Fkcourse);
            return View(await lmsContext.ToListAsync());
        }

        // GET: Studentmasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentmaster = await _context.Studentmasters
                .Include(s => s.Fkcourse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentmaster == null)
            {
                return NotFound();
            }

            return View(studentmaster);
        }

        // GET: Studentmasters/Create
        public IActionResult Create()
        {
            ViewData["Fkcourseid"] = new SelectList(_context.Coursemasters, "Id", "Id");
            return View();
        }

        // POST: Studentmasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Studname,Emailid,Password,Gender,State,City,Mobile,Address,Dob,Photo,Fkcourseid")] Studentmaster studentmaster)
        {
            if (ModelState.IsValid)
            {
                studentmaster.Password=BCrypt.Net.BCrypt.HashPassword(studentmaster.Password);
                _context.Add(studentmaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fkcourseid"] = new SelectList(_context.Coursemasters, "Id", "Id", studentmaster.Fkcourseid);
            return View(studentmaster);
        }

        // GET: Studentmasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentmaster = await _context.Studentmasters.FindAsync(id);
            if (studentmaster == null)
            {
                return NotFound();
            }
            ViewData["Fkcourseid"] = new SelectList(_context.Coursemasters, "Id", "Id", studentmaster.Fkcourseid);
            return View(studentmaster);
        }

        // POST: Studentmasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Studname,Emailid,Password,Gender,State,City,Mobile,Address,Dob,Photo,Fkcourseid")] Studentmaster studentmaster)
        {
            if (id != studentmaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentmaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentmasterExists(studentmaster.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fkcourseid"] = new SelectList(_context.Coursemasters, "Id", "Id", studentmaster.Fkcourseid);
            return View(studentmaster);
        }

        // GET: Studentmasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentmaster = await _context.Studentmasters
                .Include(s => s.Fkcourse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentmaster == null)
            {
                return NotFound();
            }

            return View(studentmaster);
        }

        // POST: Studentmasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentmaster = await _context.Studentmasters.FindAsync(id);
            if (studentmaster != null)
            {
                _context.Studentmasters.Remove(studentmaster);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Studentmasters/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Studentmasters/Login
        
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string emailid, string password)
        {
            // Step 1: find the student by email ONLY (can't filter by password anymore)
            var student = await _context.Studentmasters
                .FirstOrDefaultAsync(s => s.Emailid == emailid);

            // Step 2: if no student with that email, OR the typed password doesn't
            // match the stored hash, reject login
            if (student == null || !BCrypt.Net.BCrypt.Verify(password, student.Password))
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            // Step 3: login succeeds, same as before
            HttpContext.Session.SetInt32("StudentId", student.Id);
            HttpContext.Session.SetString("StudentName", student.Studname);
            return RedirectToAction("Index", "Course");
        }

        // Simple logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private bool StudentmasterExists(int id)
        {
            return _context.Studentmasters.Any(e => e.Id == id);
        }
    }
}