using SO00000010.Domain.Contracts.QuestionContracts;

namespace SO00000010.Application.Queries.Question
{
    public record GetQuestionByIdQuery(Guid id) : IRequest<QuestionModel>;
}