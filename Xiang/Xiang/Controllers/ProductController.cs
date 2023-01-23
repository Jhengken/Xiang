using Microsoft.AspNetCore.Mvc;

namespace Xiang.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
