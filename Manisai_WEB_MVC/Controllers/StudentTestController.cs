using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manisai_WEB_MVC.Models;
using Manisai_WEB_MVC.Filters;

namespace Manisai_WEB_MVC.Controllers
{
    [LoginCheckFilter]
    public class StudentTestController : Controller
    {
        private readonly LmsContext _context;

        public StudentTestController(LmsContext context)
        {
            _context = context;
        }

        // GET: /StudentTest/TakeTest?testId=1
        public async Task<IActionResult> TakeTest(int testId)
        {
            var test = await _context.Testmasters
                .Include(t => t.Fkcourse)
                .FirstOrDefaultAsync(t => t.Id == testId);

            if (test == null)
                return NotFound();

            var questions = await _context.Testquestions
                .Where(q => q.Fktestid == testId)
                .ToListAsync();

            ViewBag.Test = test;
            return View(questions);
        }

        // POST: /StudentTest/SubmitTest
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> SubmitTest(int testId, Dictionary<int, int> answers)
        {
            int? studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
                return RedirectToAction("Login", "Studentmasters");

            var questions = await _context.Testquestions
                .Where(q => q.Fktestid == testId)
                .ToListAsync();

            int correctCount = 0;

            foreach (var question in questions)
            {
                if (answers.TryGetValue(question.Id, out int selectedAns))
                {
                    bool isCorrect = selectedAns == question.Correctans;
                    if (isCorrect) correctCount++;

                    var detail = new Studentattemptdetail
                    {
                        Fkstudid = studentId.Value,
                        Fktestquestionid = question.Id,
                        Selectedans = selectedAns,
                        Iscorrect = isCorrect
                    };

                    _context.Studentattemptdetails.Add(detail);
                }
            }

            bool passed = questions.Count > 0 && (correctCount >= questions.Count / 2.0);

            var summary = new Studentattemptsummary
            {
                Fkstudid = studentId.Value,
                Fktestid = testId,
                Result = passed,
                Attemptdate = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.Studentattemptsummaries.Add(summary);

            await _context.SaveChangesAsync();

            ViewBag.Score = correctCount;
            ViewBag.Total = questions.Count;
            ViewBag.Passed = passed;
            return View("TestResult");
        }
    }
}