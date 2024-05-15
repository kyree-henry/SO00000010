using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using SO00000010.Application.Interfaces.Services;
using SO00000010.Presentation.Data;
using SO00000010.Presentation.Data.Swagger;

namespace SO00000010.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            return services;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.OperationFilter<SwaggerDefaultValues>();
            });

            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }

        public static IServiceCollection AddMvcServices(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddEndpointsApiExplorer();

            return services;
        }

        public static IServiceCollection AddHealthCheckServices(this IServiceCollection services)
        {

            services.AddHealthChecks()
                   .AddCheck<HealthCheck>(nameof(Presentation))
                   .AddCheck<Domain.HealthCheck>(nameof(Domain))
                   .AddCheck<Application.HealthCheck>(nameof(Application))
                   .AddCheck<HealthCheck>(nameof(Infrastructure));

            return services;
        }

    }
}