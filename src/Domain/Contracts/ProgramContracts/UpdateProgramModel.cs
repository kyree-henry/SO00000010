using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Domain.Contracts.ProgramContracts
{
    public record UpdateProgramModel : CreateProgramModel
    {
        public Guid Id { get; set; }
    }
}