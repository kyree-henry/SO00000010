using System.ComponentModel;

namespace SO00000010.Domain.Enums
{
    public enum QuestionType
    {
        [Description("Paragrah")]
        Paragrah = 10,

        [Description("Yes/No")]
        YesNo = 20,

        [Description("Dropdown")]
        Dropdown = 30,

        [Description("Date")]
        Date = 40,

        [Description("Number")]
        Number = 50
    }
}