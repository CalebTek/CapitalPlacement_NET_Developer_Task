
using CapitalPlacement.Domain.Enums;

namespace CapitalPlacement.Domain.Models
{
    public class ProgramDetails
    {
        public Guid ProgramDetailsId { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string KeySkills { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public string Criteria { get; set; } = string.Empty;

        // Additional Program Information

        public ProgramType Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public string Duration { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string MinQualification { get; set; } = string.Empty;
        public long MaxApplication { get; set;} 

    }
}
