using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CreateEmployeeDTO
    {
        public string? Organization { get; set; }
        public int UserId { get; set; }
    }
}
