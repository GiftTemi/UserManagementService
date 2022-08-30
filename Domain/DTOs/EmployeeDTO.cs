using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string? Organization { get; set; }
        public int UserId { get; set; }
    }
}
