using SO00000010.Application.Queries.Question;
using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Application.Handlers.Question
{
    public record GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionModel>
    {
        private readonly IQuestionRepository _QuestionRepository;

        public GetQuestionByIdQueryHandler(IQuestionRepository QuestionRepository)
        {
            _QuestionRepository = QuestionRepository;
        }

        public async Task<QuestionModel> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _QuestionRepository.GetByIdAsync(request.id);
        }
    }
}