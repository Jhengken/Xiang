using Microsoft.AspNetCore.Mvc;

namespace Xiang.Controllers
{
    public class AdvertiseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
