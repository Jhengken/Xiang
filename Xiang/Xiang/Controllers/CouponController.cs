using Microsoft.AspNetCore.Mvc;
using Xiang.Models;
using Xiang.ViewModels;

namespace Xiang.Controllers
{
    public class CouponController : Controller
    {
       
        public IActionResult List()
        {
            IEnumerable<Coupon> coupons = null;
            dbXContext db = new dbXContext();
            coupons = from t in db.Coupons select t;
                return View(coupons);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbXContext db = new dbXContext();
                Coupon Delcoupon = db.Coupons.FirstOrDefault(t => t.CouponId == id);
                if (Delcoupon != null)
                {
                    db.Coupons.Remove(Delcoupon);
                    db.SaveChangesAsync();
                }
            }
            return RedirectToAction("List");
        }
     
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                dbXContext db = new dbXContext();
                Coupon x = db.Coupons.FirstOrDefault(t => t.CouponId == id);
                if (x != null)
                    return View(x);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Edit(CCoupconViewModel c)
        {      
            dbXContext db = new dbXContext();
            Coupon Editcoupon = db.Coupons.FirstOrDefault(t => t.CouponId == c.CouponId);
            if (Editcoupon != null)
            {
                Editcoupon.Code = c.Code;
                Editcoupon.ExpiryDate = c.ExpiryDate;
                Editcoupon.Quantity = c.Quantity;
                Editcoupon.Discount = c.Discount;
                Editcoupon.Available = c.Available;
                db.SaveChanges();
            }         
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Create(Coupon coupon)
        {
            dbXContext db = new dbXContext();
            db.Coupons.Add(coupon);
            db.SaveChanges();
            return RedirectToAction("List");
        }
       

    }
}
