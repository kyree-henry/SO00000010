using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Domain.Contracts.ProgramContracts
{
    public record ProgramModel : UpdateProgramModel
    {
        public List<ApplicationRecordModel>? ApplicationRecords { get; set; }
    }
}