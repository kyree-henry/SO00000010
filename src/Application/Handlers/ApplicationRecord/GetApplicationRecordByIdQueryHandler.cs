using SO00000010.Application.Queries.ApplicationRecord;
using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Application.Handlers.ApplicationRecord
{
    public record GetApplicationRecordByIdQueryHandler : IRequestHandler<GetApplicationRecordByIdQuery, ApplicationRecordModel>
    {
        private readonly IApplicationRecordRepository _applicationrecordRepository;

        public GetApplicationRecordByIdQueryHandler(IApplicationRecordRepository applicationrecordRepository)
        {
            _applicationrecordRepository = applicationrecordRepository;
        }

        public async Task<ApplicationRecordModel> Handle(GetApplicationRecordByIdQuery request, CancellationToken cancellationToken)
        {
            return await _applicationrecordRepository.GetByIdAsync(request.id);
        }
    }
}