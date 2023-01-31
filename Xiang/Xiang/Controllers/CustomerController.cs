
﻿using Microsoft.AspNetCore.Mvc;

﻿using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Xiang.Models;
using Xiang.ViewModels;


namespace Xiang.Controllers
{
    public class CustomerController : Controller
    {

            public IActionResult List(KeywordViewModel vm)
            {
                IEnumerable<Customer> data = null;
                dbXContext db = new dbXContext();
                if (string.IsNullOrEmpty(vm.txtKeyword))
                    data = from t in db.Customers
                           select t;
                else
                    data = db.Customers.Where(t => t.Name.Contains(vm.txtKeyword) ||
                    t.Phone.Contains(vm.txtKeyword) ||
                    t.Email.Contains(vm.txtKeyword) ||
                    t.Address.Contains(vm.txtKeyword) ||
                    t.Birth.ToString().Contains(vm.txtKeyword));
                return View(data);
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Customer p)
            {
                dbXContext db = new dbXContext();
                db.Customers.Add(p);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            public ActionResult Delete(int? id)
            {
                if (id != null)
                {
                    dbXContext db = new dbXContext();
                    Customer delCustomer = db.Customers.FirstOrDefault(t => t.CustomerId == id);
                    if (delCustomer != null)
                    {
                        db.Customers.Remove(delCustomer);
                        db.SaveChangesAsync();
                    }
                }
                return RedirectToAction("List");
            }
            [HttpPost]
            public ActionResult Edit(Customer p)
            {
                dbXContext db = new dbXContext();
                Customer x = db.Customers.FirstOrDefault(t => t.CustomerId == p.CustomerId);
                if (x != null)
                {
                    x.Name = p.Name;
                    x.Email = p.Email;
                    x.Phone = p.Phone;
                    x.Password = p.Password;
                    x.Address = p.Address;
                    x.Birth = p.Birth;
                    x.CreditCard = p.CreditCard;
                    x.CreditPoints = p.CreditPoints;
                    x.BlackListed = p.BlackListed;

                    db.SaveChangesAsync();
                }
                return RedirectToAction("List");
            }

            public ActionResult Edit(int? id)
            {
                if (id != null)
                {
                    dbXContext db = new dbXContext();
                    Customer x = db.Customers.FirstOrDefault(t => t.CustomerId == id);
                    if (x != null)
                        return View(x);
                }
                return RedirectToAction("List");
            }
            public IActionResult Login(LoginViewModel vm)
            {
                Customer user = (new dbXContext()).Customers.FirstOrDefault(
                    t => t.Email.Equals(vm.txtAccount) && t.Password.Equals(vm.txtPassword));

                if (user != null && user.Password.Equals(vm.txtPassword))
                {
                    string json = JsonSerializer.Serialize(user);
                    HttpContext.Session.SetString(Dictionary.SK_LOGINED_USER, json);
                    return RedirectToAction("Index");

                }

                return View();
            }
        }
    } 
