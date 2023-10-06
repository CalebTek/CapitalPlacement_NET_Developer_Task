using System.ComponentModel;


namespace CapitalPlacement.Domain.Enums
{
    public enum ProgramType
    {
        [Description("Full Time")]
        FullTime = 1,
        [Description("Part Time")]
        PartTime = 2,
        [Description("Contract")]
        Contract = 3,
        [Description("Internship")]
        Internship = 4

    }
}
