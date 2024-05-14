using SO00000010.Domain.Contracts.AnswerContracts;

namespace SO00000010.Application.Queries.Answer
{
    public record GetAnswerByIdQuery(Guid id) : IRequest<AnswerModel>;
}