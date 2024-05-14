using Microsoft.Extensions.DependencyInjection;
using SO00000010.Application.Interfaces.Services;
using SO00000010.Infrastructure.Data;
using SO00000010.Infrastructure.Data.Repositories;
using SO00000010.Infrastructure.Data.Services;

namespace SO00000010.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<DbContext, DataContext>();
            services.AddDbContextFactory<DataContext>();
            services.AddDbContextFactory<DbContext>();

            services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());
            services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();

            services.AddScoped<IProgramRepository, ProgramRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            return services;
        }
    }
}