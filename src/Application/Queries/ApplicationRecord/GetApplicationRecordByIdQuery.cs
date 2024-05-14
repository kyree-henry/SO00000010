using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Application.Queries.ApplicationRecord
{
    public record GetApplicationRecordByIdQuery(Guid id) : IRequest<ApplicationRecordModel>;
}