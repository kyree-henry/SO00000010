namespace SO00000010.Domain.Entities
{
    public class Program
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public virtual ICollection<Question>? Questions { get; set; }
        public virtual ICollection<ApplicationRecord>? Applications { get; set; }
    }
}