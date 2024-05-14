using Newtonsoft.Json;

namespace SO00000010.Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = default!;

        public bool AllowOtherOption { get; set; }
        public int MaxChoice { get; set; }

        public string? Choices { get; set; }

        public Guid ProgramId { get; set; }
        public virtual Program Program { get; set; } = default!;

        public virtual ICollection<Answer>? Answers { get; set; }

        [NotMapped]
        public List<string>? ListOfChoices => JsonConvert.DeserializeObject<List<string>>(Choices!);
    }
}