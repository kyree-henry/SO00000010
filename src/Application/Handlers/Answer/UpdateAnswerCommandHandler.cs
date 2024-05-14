using SO00000010.Application.Commands.Answer;
using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Application.Handlers.Answer
{
    public record UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, AnswerModel>
    {
        private readonly IAnswerRepository _answerRepository;

        public UpdateAnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<AnswerModel> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            return await _answerRepository.UpdateAsync(request.model, cancellationToken);
        }
    }
}