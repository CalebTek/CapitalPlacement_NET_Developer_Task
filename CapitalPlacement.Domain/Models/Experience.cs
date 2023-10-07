using CapitalPlacement.Domain.Common;

namespace CapitalPlacement.Domain.Models
{
    public class Experience : BaseEntity
    {
        public string ExperienceId { get; set; } = Guid.NewGuid().ToString();
        public string Company { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}