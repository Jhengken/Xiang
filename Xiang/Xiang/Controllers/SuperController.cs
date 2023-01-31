using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Xiang.Models;

namespace Xiang.Controllers
{
    public class SuperController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           base.OnActionExecuting(context);
            if (!HttpContext.Session.Keys.Contains(MDictionary.SK_SLOGIN_USER))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Controller = "Home",
                    Action = "Login",
                }));
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
