using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Domain.Enums
{
    public enum StageType
    {
        [Description("Shortlisting")]
        Shortlisting = 1,
        [Description("Video Interview")]
        VideoInterview = 2,
        [Description("Placement")]
        Placement = 3
    }
}
