using System.ComponentModel;
using Xiang.Models;

namespace Xiang.ViewModel
{
    public class SupplierViewModel
    {

        public SupplierViewModel()
        {
            Aorders = new HashSet<Aorder>();
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }

        [DisplayName("姓名")]
        public string? Name { get; set; }
        public string? Email { get; set; }

        [DisplayName("電話")]
        public string? Phone { get; set; }

        [DisplayName("密碼")]
        public string? Password { get; set; }

        [DisplayName("地址")]
        public string? Address { get; set; }
        public int? CreditPoints { get; set; }
        public bool? BlackListed { get; set; }

        public virtual ICollection<Aorder> Aorders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
