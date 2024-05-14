using SO00000010.Application.Queries.Question;
using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Application.Handlers.Question
{
    public record GetQuestionQueryHandler : IRequestHandler<GetQuestionsQuery, IEnumerable<QuestionModel>>
    {
        private readonly IQuestionRepository _QuestionRepository;

        public GetQuestionQueryHandler(IQuestionRepository QuestionRepository)
        {
            _QuestionRepository = QuestionRepository;
        }

        public async Task<IEnumerable<QuestionModel>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            return await _QuestionRepository.GetAsync();
        }
    }
}