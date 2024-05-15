using SO00000010.Domain.Enums;

namespace SO00000010.Domain.Contracts.QuestionContracts
{
    public record CreateQuestionModel
    {
        public QuestionType Type { get; set; }
        public string Text { get; set; } = default!;
        public bool AllowOtherOption { get; set; }
        public int MaxChoice { get; set; }
        public Guid ProgramId { get; set; }
        public List<string>? Choices { get; set; }
    }
}