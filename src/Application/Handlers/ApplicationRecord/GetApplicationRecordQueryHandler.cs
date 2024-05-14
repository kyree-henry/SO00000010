using SO00000010.Application.Queries.ApplicationRecord;
using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Application.Handlers.ApplicationRecord
{
    public record GetApplicationRecordQueryHandler : IRequestHandler<GetApplicationRecordsQuery, IEnumerable<ApplicationRecordModel>>
    {
        private readonly IApplicationRecordRepository _applicationrecordRepository;

        public GetApplicationRecordQueryHandler(IApplicationRecordRepository applicationrecordRepository)
        {
            _applicationrecordRepository = applicationrecordRepository;
        }

        public async Task<IEnumerable<ApplicationRecordModel>> Handle(GetApplicationRecordsQuery request, CancellationToken cancellationToken)
        {
            return await _applicationrecordRepository.GetAsync();
        }
    }
}