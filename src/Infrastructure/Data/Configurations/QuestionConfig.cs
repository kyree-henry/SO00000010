using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO00000010.Domain.Entities;

namespace SO00000010.Infrastructure.Data.Configurations
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entity)
        {
            entity.HasMany(q => q.Answers)
            .WithOne(p => p.Question)
            .HasForeignKey(q => q.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}