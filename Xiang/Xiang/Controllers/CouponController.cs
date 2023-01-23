using Microsoft.AspNetCore.Mvc;

namespace Xiang.Controllers
{
    public class CouponController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
