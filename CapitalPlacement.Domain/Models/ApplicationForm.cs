
namespace CapitalPlacement.Domain.Models
{
    public class ApplicationForm
    {
        public string ApplicationFormId { get; set; } = Guid.NewGuid().ToString();
        public string CoverImageUrl { get; set; } = string.Empty;
        public PersonalInformation? PersonalInformation { get; set; }
        public Profile? Profile { get; set; }

        // Additional Questions
        public List<Questions>? Questions { get; set; }
    }
}
