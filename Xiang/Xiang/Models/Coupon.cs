using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class Coupon
    {
        public int CouponId { get; set; }
        public string? Code { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Quantity { get; set; }
        public bool? Available { get; set; }
    }
}
