using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Application.Queries.Answer
{
    public record GetAnswersQuery() : IRequest<IEnumerable<AnswerModel>>;
}