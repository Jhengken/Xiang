using System;
using System.Collections.Generic;

namespace Xiang.Models
{
    public partial class Manager
    {
        public int ManagerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
    }
}
