using SO00000010.Application.Commands.Question;
using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Application.Handlers.Question
{
    public record UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, QuestionModel>
    {
        private readonly IQuestionRepository _questionRepository;

        public UpdateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionModel> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            return await _questionRepository.UpdateAsync(request.model, cancellationToken);
        }
    }
}