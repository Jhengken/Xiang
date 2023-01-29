using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Xiang.Models;
using Xiang.ViewModels;
using System.IO;
using System.Xml.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Xiang.Controllers
{
    public class ProductController : Controller
    {
        IWebHostEnvironment _environment;

        public ProductController(IWebHostEnvironment p)   //IWebHostEnvironment不能new物件，所以透過建構子注入
        {
            _environment = p;
        }
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
            if (HttpContext.Session.Keys.Contains(MDictionary.SK_SLOGIN_USER))
            {
                string json = HttpContext.Session.GetString(MDictionary.SK_SLOGIN_USER);
                Supplier user = JsonSerializer.Deserialize<Supplier>(json);
                ViewBag.SupplierId = user.SupplierId;
                return View();
            }
            return RedirectToAction("Login");
        }   
        [HttpPost]
        public IActionResult Create(ProductViewModel vm)
        {
            dbXContext db = new dbXContext();
            Product p = new Product();
            p.SupplierId = vm.SupplierId;
            p.Name = vm.Name;
            p.UnitPrice = vm.UnitPrice;
            if (vm.photo != null)
            {
                string photoName = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ".jpg";
                string path = _environment.WebRootPath + "/images/" + photoName;
                p.Image = photoName;
                vm.photo.CopyToAsync(new FileStream(path, FileMode.Create));
            }
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
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
            dbXContext db =new dbXContext();
            Product x = db.Products.FirstOrDefault(t => t.ProductId == vm.ProductId);
            if (x != null)
            {
                if (vm.photo != null)
                {
                    string photoName = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ".jpg";
                    string path = _environment.WebRootPath + "/images/" + photoName;
                    if (x.Image != null)                        //刪除原有的檔案
                    {
                        //ContorllerBase也有定義File所以要加System.IO.來準確使用
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        string del = _environment.WebRootPath + "/images/" + x.Image.ToString();
                        System.IO.File.Delete(del);
                    }
                    x.Image = photoName;
                    vm.photo.CopyTo(new FileStream(path, FileMode.Create));
                }
                x.Name = vm.Name;
                x.UnitPrice = vm.UnitPrice;
                db.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbXContext db = new dbXContext();
                Product del = db.Products.FirstOrDefault(t=>t.ProductId.Equals(id));
                if (del != null)
                {
                    db.Products.Remove(del);
                    db.SaveChangesAsync();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult PSite()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PSite(PSiteViewModel vm)
        {
            return View();
        }
    }
}
