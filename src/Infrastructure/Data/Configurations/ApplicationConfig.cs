using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO00000010.Domain.Entities;

namespace SO00000010.Infrastructure.Data.Configurations
{
    public class ApplicationConfig : IEntityTypeConfiguration<ApplicationRecord>
    {
        public void Configure(EntityTypeBuilder<ApplicationRecord> entity)
        {
            entity.HasOne(ap => ap.Program)
            .WithMany(p => p.Applications)
            .HasForeignKey(ap => ap.ProgramId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}