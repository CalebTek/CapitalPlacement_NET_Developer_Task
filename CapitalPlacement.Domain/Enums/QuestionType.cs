using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Domain.Enums
{
    public enum QuestionType
    {
        [Description("Paragraph")]
        Paragraph = 1,
        [Description("Short answer")]
        ShortAnswer = 2,
        [Description("Yes/No")]
        YesNo = 3,
        [Description("Drop down")]
        DropDown = 4,
        [Description("Multiple choice")]
        MultipleChoice = 5,
        [Description("Date")]
        Date = 6,
        [Description("Number")]
        Number = 7,
        [Description("FileUpload")]
        FileUpload = 8,
        [Description("Video question")]
        VideoQuestion = 9,

    }
}
