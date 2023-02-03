using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Xiang.Models
{
    public class ProductMetadata
    {
            public ProductMetadata()
            {
                Corders = new HashSet<Corder>();
                Evaluations = new HashSet<Evaluation>();
                Psites = new HashSet<Psite>();
            }

            public int ProductId { get; set; }
            public int? SupplierId { get; set; }
            [Display(Name = "產品名稱稱")]
            public string? Name { get; set; }
            public int? UnitPrice { get; set; }
            public string? Image { get; set; }

            public virtual Supplier? Supplier { get; set; }
            public virtual ICollection<Corder> Corders { get; set; }
            public virtual ICollection<Evaluation> Evaluations { get; set; }
            public virtual ICollection<Psite> Psites { get; set; }
    }
}
