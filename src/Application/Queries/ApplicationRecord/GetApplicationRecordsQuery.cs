using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Application.Queries.ApplicationRecord
{
    public record GetApplicationRecordsQuery() : IRequest<IEnumerable<ApplicationRecordModel>>;
}