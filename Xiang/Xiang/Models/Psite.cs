using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class Psite
    {
        public int SiteId { get; set; }
        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public int? UnitOrPing { get; set; }
        public int? UnitInStock { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

        public virtual Product? Product { get; set; }
    }
}
