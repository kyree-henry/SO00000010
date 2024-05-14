using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Domain.Contracts.AnswerContracts
{
    public record AnswerModel : UpdateAnswerModel
    {
        public QuestionModel? Question { get; set; }
    }
}