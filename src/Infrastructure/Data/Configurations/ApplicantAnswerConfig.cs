using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SO00000010.Infrastructure.Data.Configurations
{
    public class ApplicantAnswerConfig : IEntityTypeConfiguration<ApplicantAnswer>
    {
        public void Configure(EntityTypeBuilder<ApplicantAnswer> entity)
        {
            entity.HasKey(q => new { q.AnswerId, q.ApplicationId });
        }
    }
}