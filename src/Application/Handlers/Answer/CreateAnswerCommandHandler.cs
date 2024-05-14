using SO00000010.Application.Commands.Answer;
using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Application.Handlers.Answer
{
    public record CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, AnswerModel>
    {
        private readonly IAnswerRepository _answerRepository;

        public CreateAnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<AnswerModel> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            return await _answerRepository.CreateAsync(request.model, cancellationToken);
        }
    }
}