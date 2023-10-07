using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Domain.Models
{
    public class Profile
    {
        public string ProfileId { get; set; } = Guid.NewGuid().ToString();
        public ICollection<Education>? Educations { get; set; }
        public ICollection<Experience>? Experiences { get; set; }
        public string ResumeUrl { get; set; } = string.Empty;
        public ICollection<Questions>? Questions { get; set; }
    }
}
