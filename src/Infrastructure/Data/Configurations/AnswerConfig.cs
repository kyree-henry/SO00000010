using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO00000010.Domain.Entities;

namespace SO00000010.Infrastructure.Data.Configurations
{
    public class AnswerConfig : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> entity)
        {
            
        }
    }
}