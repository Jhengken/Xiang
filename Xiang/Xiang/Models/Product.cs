using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class Product
    {
        public Product()
        {
            Corders = new HashSet<Corder>();
            Evaluations = new HashSet<Evaluation>();
            Psites = new HashSet<Psite>();
        }

        public int ProductId { get; set; }
        public int? SupplierId { get; set; }
        public string? Name { get; set; }
        public int? UnitPrice { get; set; }
        public string? Image { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<Corder> Corders { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<Psite> Psites { get; set; }
    }
}
