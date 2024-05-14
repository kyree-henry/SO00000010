using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Application.Interfaces.Repositories
{
    public interface IApplicationRecordRepository
    {
        Task<IEnumerable<ApplicationRecordModel>> GetAsync();
        Task<ApplicationRecordModel> GetByIdAsync(Guid id);
        Task<ApplicationRecordModel> CreateAsync(CreateApplicationRecordModel data, CancellationToken cancellationToken = new());
        Task<ApplicationRecordModel> UpdateAsync(UpdateApplicationRecordModel data, CancellationToken cancellationToken = new());
    }
}