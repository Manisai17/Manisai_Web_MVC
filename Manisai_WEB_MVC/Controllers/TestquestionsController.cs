using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manisai_WEB_MVC.Models;

namespace Manisai_WEB_MVC.Controllers
{
    public class TestquestionsController : Controller
    {
        private readonly LmsContext _context;

        public TestquestionsController(LmsContext context)
        {
            _context = context;
        }

        // GET: Testquestions
        public async Task<IActionResult> Index(int? testId)
        {
            var query = _context.Testquestions.Include(t => t.Fktest);

            if (testId != null)
            {
                var filtered = query.Where(q => q.Fktestid == testId);
                ViewBag.TestId = testId;
                return View(await filtered.ToListAsync());
            }

            return View(await query.ToListAsync());
        }

        // GET: Testquestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testquestion = await _context.Testquestions
                .Include(t => t.Fktest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testquestion == null)
            {
                return NotFound();
            }

            return View(testquestion);
        }

        // GET: Testquestions/Create
        public IActionResult Create(int? testId)
        {
            ViewData["Fktestid"] = new SelectList(_context.Testmasters, "Id", "Testname", testId);
            return View();
        }

        // POST: Testquestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fktestid,Question,Answer1,Answer2,Answer3,Answer4,Correctans,Explanation")] Testquestion testquestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testquestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fktestid"] = new SelectList(_context.Testmasters, "Id", "Id", testquestion.Fktestid);
            return View(testquestion);
        }

        // GET: Testquestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testquestion = await _context.Testquestions.FindAsync(id);
            if (testquestion == null)
            {
                return NotFound();
            }
            ViewData["Fktestid"] = new SelectList(_context.Testmasters, "Id", "Id", testquestion.Fktestid);
            return View(testquestion);
        }

        // POST: Testquestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fktestid,Question,Answer1,Answer2,Answer3,Answer4,Correctans,Explanation")] Testquestion testquestion)
        {
            if (id != testquestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testquestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestquestionExists(testquestion.Id))
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
            ViewData["Fktestid"] = new SelectList(_context.Testmasters, "Id", "Id", testquestion.Fktestid);
            return View(testquestion);
        }

        // GET: Testquestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testquestion = await _context.Testquestions
                .Include(t => t.Fktest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testquestion == null)
            {
                return NotFound();
            }

            return View(testquestion);
        }

        // POST: Testquestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testquestion = await _context.Testquestions.FindAsync(id);
            if (testquestion != null)
            {
                _context.Testquestions.Remove(testquestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestquestionExists(int id)
        {
            return _context.Testquestions.Any(e => e.Id == id);
        }
    }
}
