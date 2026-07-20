using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Manisai_WEB_MVC.Filters
{
    public class LoginCheckFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var studentId = context.HttpContext.Session.GetInt32("StudentId");

            if (studentId == null)
            {
                context.Result = new RedirectToActionResult("Login", "Studentmasters", null);
            }

            base.OnActionExecuting(context);
        }
    }
}