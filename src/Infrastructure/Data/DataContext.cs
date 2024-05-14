using SO00000010.Application.Interfaces.Services;
using System.Reflection;

namespace SO00000010.Infrastructure.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<ApplicationRecord> Applications => Set<ApplicationRecord>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Program> Programs => Set<Program>();
        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<AppUser> Users => Set<AppUser>();
    }
}