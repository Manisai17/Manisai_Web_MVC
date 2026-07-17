using Manisai_WEB_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Manisai_WEB_MVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly LmsContext _context;
        public CourseController(LmsContext context)
        {
            _context = context;
        }
        //1. View courses
       
        //i)GET ACTION : INDEX for  GetAllCourses : view bag shows all available courses

        public IActionResult Index()
        {
            ViewBag.courses= _context.Coursemasters.ToList();
            return View();
        }
        //ii) Get single course details
        public IActionResult Details(int courseid)
        {

            var course = _context.Coursemasters.FirstOrDefault(cm => cm.Id == courseid);
            if (course == null)
            {
                return View("NotFound");
            }
            return View(course);
        }

        //2. Add Course
        //i) GET=> AddCourse =>view in which we get an empty form that we use to fill new course
        public IActionResult AddCourse()
        {
            //Nothing to supply to view as this is an completely empty form 
            return View(new Coursemaster());
        }
        //ii)POST=> AddCourse => action to accept the course detailed entered in empty form and save
        [HttpPost]
        // public IActionResult AddCourse(string coursename , string description , int duration , string modules)
        public IActionResult AddCourse([Bind("Coursename, Description,Duration,Modules")] Coursemaster coursemaster)
        {
            _context.Coursemasters.Add(coursemaster);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        //3.Edit
        //i) GET Action=> EditCourse to  get id as input and return a View which is showing existing Course
        public IActionResult EditCourse(int courseid)
        {
            var course=_context.Coursemasters.FirstOrDefault(cm=>cm.Id == courseid);
            if (course == null)
            {
                return View("NotFound");
            }

            return View(course);
        }
        //ii) POST Action=> EditCourse  to acccept the edited course details and updatee the course
        [HttpPost]
        public IActionResult EditCourse(int id, [Bind("Id,Coursename,Description,Duration,Modules")] Coursemaster coursemaster)
        {
            //add required model object or viewbag and then return the view 
            // return View(GetAllCourses);
            _context.Coursemasters.Update(coursemaster);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //4.Delete
        //i)GET ACtion => DeleteCourse to get id as input to  show confirmation page
        public IActionResult DeleteConfirmation(int courseid)
        {
            var course = _context.Coursemasters.FirstOrDefault(cm => cm.Id == courseid);
             if (course == null)
            {
                return View("NotFound");
            }
            return View(course);
        }
        //ii)POST Action=> DeleteCourse to get the id of course to be deleted 
        public IActionResult DeleteCourse(int courseid)
        {
            var course = _context.Coursemasters.FirstOrDefault(cm => cm.Id == courseid);
            _context.Coursemasters.Remove(course);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
