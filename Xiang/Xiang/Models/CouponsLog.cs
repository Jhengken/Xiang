using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class CouponsLog
    {
        public int CouponId { get; set; }
        public int? OrderId { get; set; }

        public virtual Corder? Order { get; set; }
    }
}
