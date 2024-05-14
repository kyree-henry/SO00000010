using SO00000010.Application.Queries.Answer;
using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Application.Handlers.Answer
{
    public record GetAnswerQueryHandler : IRequestHandler<GetAnswersQuery, IEnumerable<AnswerModel>>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerQueryHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<IEnumerable<AnswerModel>> Handle(GetAnswersQuery request, CancellationToken cancellationToken)
        {
            return await _answerRepository.GetAsync();
        }
    }
}