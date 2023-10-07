using CapitalPlacement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Domain.Models
{
    public class Questions
    {
        public string QuestionId { get; set; } = Guid.NewGuid().ToString();
        public QuestionType Type { get; set; }
        public string Question { get; set; } = string.Empty;
    }
}
