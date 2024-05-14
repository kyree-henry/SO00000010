using Microsoft.EntityFrameworkCore;
using SO00000010.Domain.Entities;

namespace SO00000010.Application.Interfaces.Services
{
    public interface IDataContext
    {
        DbSet<Question> Questions { get; }
        DbSet<Answer> Answers { get; }
        DbSet<Program> Programs { get; }
        DbSet<AppUser> Users { get; }
        DbSet<ApplicationRecord> Applications { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}