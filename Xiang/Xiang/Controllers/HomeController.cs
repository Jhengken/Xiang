using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using Xiang.Models;

namespace Xiang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            using(dbXContext db = new dbXContext())
            { 
                var productDetail = (from t in db.Products where t.ProductId == id select t).FirstOrDefault();
                if(productDetail == default(Models.Product))
                 {
                    return View(Index);
                }
                else
                     return View(productDetail);  
            }
           
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}