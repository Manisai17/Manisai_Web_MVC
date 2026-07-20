using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manisai_WEB_MVC.Models;
using Manisai_WEB_MVC.Filters;

namespace Manisai_WEB_MVC.Controllers
{
    [LoginCheckFilter]
    public class CoursemastersController : Controller
    {
        private readonly LmsContext _context;

        public CoursemastersController(LmsContext context)
        {
            _context = context;
        }

        // GET: Coursemasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coursemasters.ToListAsync());
        }

        // GET: Coursemasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursemaster = await _context.Coursemasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursemaster == null)
            {
                return NotFound();
            }

            return View(coursemaster);
        }

        // GET: Coursemasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coursemasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Coursename,Description,Modules,Duration")] Coursemaster coursemaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursemaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coursemaster);
        }

        // GET: Coursemasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursemaster = await _context.Coursemasters.FindAsync(id);
            if (coursemaster == null)
            {
                return NotFound();
            }
            return View(coursemaster);
        }

        // POST: Coursemasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Coursename,Description,Modules,Duration")] Coursemaster coursemaster)
        {
            if (id != coursemaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursemaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursemasterExists(coursemaster.Id))
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
            return View(coursemaster);
        }

        // GET: Coursemasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursemaster = await _context.Coursemasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursemaster == null)
            {
                return NotFound();
            }

            return View(coursemaster);
        }

        // POST: Coursemasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coursemaster = await _context.Coursemasters.FindAsync(id);
            if (coursemaster != null)
            {
                _context.Coursemasters.Remove(coursemaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursemasterExists(int id)
        {
            return _context.Coursemasters.Any(e => e.Id == id);
        }
    }
}
