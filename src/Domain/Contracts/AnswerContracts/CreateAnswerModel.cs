namespace SO00000010.Domain.Contracts.AnswerContracts
{
    public record CreateAnswerModel
    {
        public string? Text { get; set; }
        public Guid QuestionId { get; set; }
        public Guid ApplicationId { get; set; }
    }
}