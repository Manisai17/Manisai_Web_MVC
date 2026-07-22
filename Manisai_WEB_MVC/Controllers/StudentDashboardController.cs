using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manisai_WEB_MVC.Models;
using Manisai_WEB_MVC.Filters;

namespace Manisai_WEB_MVC.Controllers
{
    [LoginCheckFilter]
    public class StudentDashboardController : Controller
    {
        private readonly LmsContext _context;

        public StudentDashboardController(LmsContext context)
        {
            _context = context;
        }

        // GET: /StudentDashboard
        public async Task<IActionResult> Index()
        {
            int? studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
                return RedirectToAction("Login", "Studentmasters");

            var attempts = await _context.Studentattemptsummaries
                .Include(s => s.Fktest)
                .Where(s => s.Fkstudid == studentId)
                .OrderByDescending(s => s.Attemptdate)
                .ToListAsync();

            return View(attempts);
        }

        // GET: /StudentDashboard/Details?testId=1
        public async Task<IActionResult> Details(int testId)
        {
            int? studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
                return RedirectToAction("Login", "Studentmasters");

            var test = await _context.Testmasters.FirstOrDefaultAsync(t => t.Id == testId);
            if (test == null)
                return NotFound();

            var details = await _context.Studentattemptdetails
                .Include(d => d.Fktestquestion)
                .Where(d => d.Fkstudid == studentId && d.Fktestquestion.Fktestid == testId)
                .ToListAsync();

            ViewBag.Test = test;
            return View(details);
        }
    }
}