using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Application.Commands.Answer
{
    public record UpdateAnswerCommand(UpdateAnswerModel model) : IRequest<AnswerModel>;
}