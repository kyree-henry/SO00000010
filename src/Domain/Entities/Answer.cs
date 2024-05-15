namespace SO00000010.Domain.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }

        public Guid QuestionId { get; set; }
        public virtual Question? Question { get; set; }
    }
}