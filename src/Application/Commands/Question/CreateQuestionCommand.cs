using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Application.Commands.Question
{
    public record CreateQuestionCommand(CreateQuestionModel model) : IRequest<QuestionModel>;
}