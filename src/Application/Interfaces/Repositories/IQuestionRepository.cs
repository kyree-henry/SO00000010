using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Application.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<QuestionModel>> GetAsync();
        Task<QuestionModel> GetByIdAsync(Guid id);
        Task<QuestionModel> CreateAsync(CreateQuestionModel data, CancellationToken cancellationToken = new());
        Task<QuestionModel> UpdateAsync(UpdateQuestionModel data, CancellationToken cancellationToken = new());
    }
}