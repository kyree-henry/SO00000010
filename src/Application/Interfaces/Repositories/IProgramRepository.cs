using SO00000010.Domain.Contracts.ProgramContracts;

namespace SO00000010.Application.Interfaces.Repositories
{
    public interface IProgramRepository
    {
        Task<IEnumerable<ProgramModel>> GetAsync();
        Task<ProgramModel> GetByIdAsync(Guid id);
        Task<ProgramModel> CreateAsync(CreateProgramModel data, CancellationToken cancellationToken = new ());
        Task<ProgramModel> UpdateAsync(UpdateProgramModel data, CancellationToken cancellationToken = new ());
    }
}