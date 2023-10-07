using CapitalPlacement.Domain.Enums;

namespace CapitalPlacement.Domain.Models
{
    public class PersonalInformation
    {
        
        public string PersonalId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string CurrentResidence { get; set; } = string.Empty;
        public string IdentityNumber { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Questions>? Questions { get; set; }
        
    }
}