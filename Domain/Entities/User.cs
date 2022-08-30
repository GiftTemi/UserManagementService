using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User:AuditEntity
    {
        public string? FirstName { get; set; }
        public string? lastName { get; set; }
        public string FullName{ get { return $"{FirstName} {lastName}"; }}
        public string? EmailAddress{ get; set; }
        public DateTime DOB { get; set; }
    }
}
