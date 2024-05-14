using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SO00000010.Application.Interfaces.Services;
using SO00000010.Infrastructure.Data;

namespace SO00000010.Infrastructure.Extensions
{
    public static class HostExtensions
    {
        public static IHost ConfigureHost(this IHost host)
        {
            BootstrapDatabaseAsync(host);
            return host;
        }

        private static async void BootstrapDatabaseAsync(IHost host)
        {
            using IServiceScope scope = ServiceProviderServiceExtensions.CreateScope(host.Services);

            // Run Health Check Services
            await ServiceProviderServiceExtensions.GetRequiredService<HealthCheckService>(scope.ServiceProvider).CheckHealthAsync();

            // Migrate Database
            //DataContext? context = ServiceProviderServiceExtensions.GetRequiredService<DataContext>(scope.ServiceProvider);
            //await context?.Database?.MigrateAsync()!;

            // Initialize Database Seed
            //IDatabaseSeeder service = ServiceProviderServiceExtensions.GetService<IDatabaseSeeder>(scope.ServiceProvider)!;
            //if (service != null)
            //{
            //    await service.Initialize();
            //}
        }
    }
}
