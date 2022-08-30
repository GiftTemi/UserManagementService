using Domain.Common;

namespace Domain.Entities
{
    public class Employee: AuditEntity
    {
        public string? Organization { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}