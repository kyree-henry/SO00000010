using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Domain.Contracts.ProgramContracts
{
    public record CreateProgramModel
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public List<QuestionModel>? Questions { get; set; }
    }
}