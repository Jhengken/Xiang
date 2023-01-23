using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Corders = new HashSet<Corder>();
            Evaluations = new HashSet<Evaluation>();
        }

        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public DateTime? Birth { get; set; }
        public string? CreditCard { get; set; }
        public int? CreditPoints { get; set; }
        public bool? BlackListed { get; set; }

        public virtual ICollection<Corder> Corders { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}
