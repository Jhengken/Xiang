using Microsoft.AspNetCore.Mvc;

namespace Xiang.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
