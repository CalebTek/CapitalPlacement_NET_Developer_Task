
using CapitalPlacement.Domain.Enums;

namespace CapitalPlacement.Domain.Models
{
    public class Stage
    {
        public string StageId { get; set; } = Guid.NewGuid().ToString();
        public string  StageName { get; set; } = string.Empty;
        public StageType StageDescription { get; set; }
    }
}
