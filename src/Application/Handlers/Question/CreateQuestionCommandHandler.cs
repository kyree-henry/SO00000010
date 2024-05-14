using SO00000010.Application.Commands.Question;
using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Application.Handlers.Question
{
    public record CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionModel>
    {
        private readonly IQuestionRepository _QuestionRepository;

        public CreateQuestionCommandHandler(IQuestionRepository QuestionRepository)
        {
            _QuestionRepository = QuestionRepository;
        }

        public async Task<QuestionModel> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            return await _QuestionRepository.CreateAsync(request.model, cancellationToken);
        }
    }
}