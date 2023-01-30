using Microsoft.AspNetCore.Mvc;
using Xiang.Models;

namespace Xiang.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult List()
        {
            IEnumerable<Supplier> datas = null;
            dbXContext db=new dbXContext();
            datas = from t in db.Suppliers
                    select t;
            return View(datas);
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Supplier p)
        {
            dbXContext db = new dbXContext();
            db.Suppliers.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
