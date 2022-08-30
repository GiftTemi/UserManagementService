using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : AuditEntity
    {
        public string? Organization { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
