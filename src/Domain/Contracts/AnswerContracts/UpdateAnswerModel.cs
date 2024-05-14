namespace SO00000010.Domain.Contracts.AnswerContracts
{
    public record UpdateAnswerModel : CreateAnswerModel
    {
        public Guid Id { get; set; }
    }
}