﻿namespace SO00000010.Domain.Contracts.ApplicationRecordContracts
{
    public record CreateApplicationRecordModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? CurrentResident { get; set; }
        public string? IdNumber { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public Guid ProgramId { get; set; }
    }
}
