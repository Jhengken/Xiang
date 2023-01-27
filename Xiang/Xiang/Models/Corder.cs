using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class Corder
    {
        public Corder()
        {
            CouponsLogs = new HashSet<CouponsLog>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? TakeDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? Code { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<CouponsLog> CouponsLogs { get; set; }
    }
}
