using SO00000010.Application.Interfaces.Services;

namespace SO00000010.Presentation.Data
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        private readonly IConfiguration _configuration;

        public DatabaseConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration!.GetConnectionString("SqlConnectionString")!;
        }
    }
}