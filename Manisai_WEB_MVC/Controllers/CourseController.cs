using Manisai_WEB_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Manisai_WEB_MVC.Controllers
{
    public class CourseController : Controller
    {
        //Creating instance of Dbcontext as private and readonly

        private readonly LmsContext _lmscontext;

        // Getting the object of Dbcontext supplied by application as a  parameter :: dependency injection
        public CourseController(LmsContext lmscontext)
        {
            _lmscontext = lmscontext;   
        }

        
        //Action for getting all courses list
        public IActionResult Index()
        {
            List<Coursemaster> courses = _lmscontext.Coursemasters.ToList();
            ViewBag.courses = courses; //binding model to view bag
            return View();
        }

        //Action for showing course details of selected course


        //Action for asking a new page for entering a new course details


        //Action for saving the new course

        //Action for asking the edit page to edit an existing course
        public IActionResult Edit(int Id)
        {
            Coursemaster course = _lmscontext.Coursemasters.FirstOrDefault(cm => cm.Id == Id);
            if(course == null)
            {
                return View("NotFound");
            }

            return View(course);  //binding model  directly to vieww 
        }

        //Action for updating the edited details of the course
        public IActionResult Update(int Id, string coursename, string Description, string modules, int duration)
        {
            Coursemaster course = _lmscontext.Coursemasters.FirstOrDefault(cm => cm.Id == Id);
            course.Coursename = coursename;
            course.Description = Description;
            course.Duration = duration;
            course.Modules = modules;
            _lmscontext.SaveChanges();


            List<Coursemaster> courses = _lmscontext.Coursemasters.ToList();
            ViewBag.courses=courses;

            return View("Index");
        }


        //Action for confirming the  delete of a course'


    }
}
