namespace SO00000010.Domain.Contracts.QuestionContracts
{
    public record UpdateQuestionModel : CreateQuestionModel
    {
        public Guid Id { get; set; }

    }
}