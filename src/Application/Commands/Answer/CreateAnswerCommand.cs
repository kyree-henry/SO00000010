using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Application.Commands.Answer
{
    public record CreateAnswerCommand(CreateAnswerModel model) : IRequest<AnswerModel>;
}