using SO00000010.Application.Queries.Answer;
using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Application.Handlers.Answer
{
    public record GetAnswerByIdQueryHandler : IRequestHandler<GetAnswerByIdQuery, AnswerModel>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerByIdQueryHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<AnswerModel> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _answerRepository.GetByIdAsync(request.id);
        }
    }
}