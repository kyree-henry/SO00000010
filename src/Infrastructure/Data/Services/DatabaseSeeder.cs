using SO00000010.Application.Interfaces.Services;

namespace SO00000010.Infrastructure.Data.Services
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly DataContext _context;
        public DatabaseSeeder(DataContext context)
        {
            _context = context;
        }

        public async Task Initialize()
        {
            await AddEmployerAccount();
        }

        static async Task AddEmployerAccount()
        {

        }
    }
}