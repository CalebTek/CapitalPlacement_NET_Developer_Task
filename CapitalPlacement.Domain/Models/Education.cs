using CapitalPlacement.Domain.Common;

namespace CapitalPlacement.Domain.Models
{
    public class Education : BaseEntity
    {
        public Guid EducationId { get; set; } = Guid.NewGuid();
        public string  School { get; set; } = string.Empty;
        public string  Degree { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string LocationOfStudy { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

    }
}