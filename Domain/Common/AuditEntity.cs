using Domain.Enums;

namespace Domain.Common
{
    public class AuditEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Status  Status { get; set; }
        public string  StatusDescription { get { return Status.ToString(); } }
    }
}
