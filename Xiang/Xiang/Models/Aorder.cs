using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class Aorder
    {
        public int AorderId { get; set; }
        public int? SupplierId { get; set; }
        public int? AdvertiseId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Clicks { get; set; }

        public virtual Advertise? Advertise { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}
