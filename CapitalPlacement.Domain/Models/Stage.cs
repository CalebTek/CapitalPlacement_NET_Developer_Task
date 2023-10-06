
using CapitalPlacement.Domain.Enums;

namespace CapitalPlacement.Domain.Models
{
    public class Stage
    {
        public Guid StageId { get; set; } = Guid.NewGuid();
        public string  StageName { get; set; } = string.Empty;
        public StageType StageDescription { get; set; }
    }
}
