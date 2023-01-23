using Microsoft.AspNetCore.Mvc;

namespace Xiang.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
