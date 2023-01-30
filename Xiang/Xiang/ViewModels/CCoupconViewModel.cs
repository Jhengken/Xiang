using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Xiang.Models;

namespace Xiang.ViewModels
{
    public class CCoupconViewModel 
    {
        private Coupon _coupon;

        public Coupon coupon 
        { 
          get { return _coupon;}
          set { _coupon = value; }
        }
        public CCoupconViewModel() { _coupon = new Coupon(); }
        public int CouponId 
        { 
            get { return _coupon.CouponId; } 
            set { _coupon.CouponId = value; } 
        }

        [DisplayName("優惠卷折扣碼")]
        [Required(ErrorMessage = "優惠卷折扣碼為必填")]
        public string? Code
        {
            get { return _coupon.Code; }
            set { _coupon.Code = value; }
        }

        [Display(Name = "折扣趴數")]
        public decimal? Discount
        {
            get { return _coupon.Discount; }
            set { _coupon.Discount = value; }
        }
        public DateTime? ExpiryDate
        {
            get { return _coupon.ExpiryDate; }
            set { _coupon.ExpiryDate = value; }
        }
        public int? Quantity
        {
            get { return _coupon.Quantity; }
            set { _coupon.Quantity = value; }
        }
        public bool? Available
        {
            get { return _coupon.Available; }
            set
            {
                _coupon.Available = value;
            }
        }
      
    }
}
