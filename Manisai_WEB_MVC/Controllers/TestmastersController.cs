
using Manisai_WEB_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLM_WEB_MVC.Controllers
{
    public class TestmastersController : Controller
    {
        private readonly LmsContext _context;

        public TestmastersController(LmsContext context)
        {
            _context = context;
        }

        // GET: Testmasters
        public async Task<IActionResult> Index()
        {
            var lmsContext = _context.Testmasters.Include(t => t.Fkcourse);
            return View(await lmsContext.ToListAsync());
        }

        // GET: Testmasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testmaster = await _context.Testmasters
                .Include(t => t.Fkcourse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testmaster == null)
            {
                return NotFound();
            }

            return View(testmaster);
        }

        // GET: Testmasters/Create
        public IActionResult Create()
        {
            ViewBag.courses = _context.Coursemasters.ToList();
            return View(new Testmaster());//Binding empty model
        }

        // POST: Testmasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fkcourseid,Testname,Duration,Totquestions")] Testmaster testmaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testmaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fkcourseid"] = _context.Coursemasters.ToList();
            return View(testmaster);
        }

        public IActionResult Test()
        {
            //var testmaster = _context.Testmasters.FirstOrDefault(test => test.Id == 1);

            ViewBag.courses = _context.Coursemasters.ToList();
            return View();

            //return View(testmaster);
        }

        // GET: Testmasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testmaster = await _context.Testmasters.FindAsync(id);
            if (testmaster == null)
            {
                return NotFound();
            }
            ViewData["Fkcourseid"] = new SelectList(_context.Coursemasters, "Id", "Coursename", testmaster.Fkcourseid);
            //new SelectList(List<course>, valueFiled, TextFiled, selectedValueTobeSavedinDB);
            return View(testmaster);
        }

        // POST: Testmasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fkcourseid,Testname,Duration,Totquestions")] Testmaster testmaster)
        {
            if (id != testmaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testmaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestmasterExists(testmaster.Id))
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
            ViewData["Fkcourseid"] = new SelectList(_context.Coursemasters, "Id", "Coursename", testmaster.Fkcourseid);
            return View(testmaster);
        }

        // GET: Testmasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testmaster = await _context.Testmasters
                .Include(t => t.Fkcourse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testmaster == null)
            {
                return NotFound();
            }

            return View(testmaster);
        }

        // POST: Testmasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testmaster = await _context.Testmasters.FindAsync(id);
            if (testmaster != null)
            {
                _context.Testmasters.Remove(testmaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestmasterExists(int id)
        {
            return _context.Testmasters.Any(e => e.Id == id);
        }


    }
}
