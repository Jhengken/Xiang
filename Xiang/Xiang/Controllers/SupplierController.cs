using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Xiang.Models;
=======
>>>>>>> origin/feature/Customer

namespace Xiang.Controllers
{
    public class SupplierController : Controller
    {
<<<<<<< HEAD
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

=======
        public IActionResult Index()
        {
            return View();
        }
>>>>>>> origin/feature/Customer
    }
}
