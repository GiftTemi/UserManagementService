using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UpdateEmployeeDTO
    {
        public string? Organization { get; set; }
        public Status Status { get; set; }
    }
}
