using SO00000010.Domain.Enums;

namespace SO00000010.Domain.Entities
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }

        public string UserName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        public AccountType AccountType { get; set; }
    }
}