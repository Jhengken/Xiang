using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Xiang.Models;
using Xiang.ViewModels;

namespace Xiang.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            IEnumerable<Product> data = null;
            dbXContext db =new dbXContext();
            data = from t in db.Products
                   select t;
            return View(data);
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(SLoginViewModel vm)
        {
            Supplier user = new dbXContext().Suppliers.FirstOrDefault(t => t.Email.Equals(vm.txtAccount) && t.Password.Equals(vm.txtPassword));
            if (user != null && user.Password.Equals(vm.txtPassword))
            {
                string json = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString(MDictionary.SK_SLOGIN_USER, json);
                return RedirectToAction("List");
            }
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel vm)
        {

            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                dbXContext db = new dbXContext();
                Product x =db.Products.FirstOrDefault(t=>t.ProductId.Equals(id));
                if (x != null)
                {
                    return View(x);
                }
            }
            return View("List");
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel vm)
        {

            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

    }
}
