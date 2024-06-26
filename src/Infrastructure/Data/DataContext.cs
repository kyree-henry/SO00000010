﻿using SO00000010.Application.Interfaces.Services;
using SO00000010.Infrastructure.Data.Configurations;
using System.Reflection;

namespace SO00000010.Infrastructure.Data
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly IDatabaseConfiguration _config;
        public DataContext(DbContextOptions options, IDatabaseConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString(), b => b.MigrationsAssembly("SO00000010.Presentation"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicantAnswerConfig());
            builder.ApplyConfiguration(new ApplicationConfig());
            builder.ApplyConfiguration(new QuestionConfig());
        }

        public DbSet<ApplicationRecord> Applications => Set<ApplicationRecord>();
        public DbSet<ApplicantAnswer> ApplicantAnswers => Set<ApplicantAnswer>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Program> Programs => Set<Program>();
        public DbSet<Answer> Answers => Set<Answer>();
    }
}