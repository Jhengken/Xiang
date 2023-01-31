using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Xiang.Models
{
    public partial class Coupon
    {
        public int CouponId { get; set; }
        public string? Code { get; set; }
        public decimal? Discount { get; set; }
       // [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }
        public int? Quantity { get; set; }

        public bool? Available { get; set; }
    }
}
