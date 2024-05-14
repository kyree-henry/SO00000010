using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO00000010.Domain.Entities;

namespace SO00000010.Infrastructure.Data.Configurations
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entity)
        {
            entity.HasOne(q => q.Program)
            .WithMany(p => p.Questions)
            .HasForeignKey(q => q.ProgramId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}