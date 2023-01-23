using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class Evaluation
    {
        public int EvaluationId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? Date { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Response { get; set; }
        public int? Star { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
    }
}
