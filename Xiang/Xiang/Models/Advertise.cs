using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class Advertise
    {
        public Advertise()
        {
            Aorders = new HashSet<Aorder>();
        }

        public int AdvertiseId { get; set; }
        public string? Name { get; set; }
        public int? UnitPrice { get; set; }

        public virtual ICollection<Aorder> Aorders { get; set; }
    }
}
