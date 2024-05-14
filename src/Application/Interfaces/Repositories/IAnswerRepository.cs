using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Application.Interfaces.Repositories
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<AnswerModel>> GetAsync();
        Task<AnswerModel> GetByIdAsync(Guid id);
        Task<AnswerModel> CreateAsync(CreateAnswerModel data, CancellationToken cancellationToken = new());
        Task<AnswerModel> UpdateAsync(UpdateAnswerModel data, CancellationToken cancellationToken = new());
    }
}