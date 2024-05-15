using SO00000010.Application;
using SO00000010.Domain;
using SO00000010.Infrastructure;

namespace SO00000010.Presentation
{
    public class Startup
    {
        public IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseServices();

            services.AddDomain();
            services.AddApplication();
            services.AddMvcServices();
            services.AddInfrastructure();
            services.AddSwaggerServices();
            services.AddHealthCheckServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionMiddleware();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(policy => {
                policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}