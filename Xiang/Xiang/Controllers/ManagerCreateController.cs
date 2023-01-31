using Microsoft.AspNetCore.Mvc;
using Xiang.Models;

namespace Xiang.Controllers
{
    public class ManagerCreateController : Controller
    {
            public IActionResult Create()
            {

                return View();
            }
            [HttpPost]
            public IActionResult Create(Manager m)
            {
                dbXContext db = new dbXContext();
                db.Managers.Add(m);
                db.SaveChanges();
                return RedirectToAction("List");

            
        }
    }
}
