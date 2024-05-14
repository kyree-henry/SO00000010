using SO00000010.Application.Commands.ApplicationRecord;
using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Application.Handlers.ApplicationRecord
{
    public record UpdateApplicationRecordCommandHandler : IRequestHandler<UpdateApplicationRecordCommand, ApplicationRecordModel>
    {
        private readonly IApplicationRecordRepository _applicationrecordRepository;

        public UpdateApplicationRecordCommandHandler(IApplicationRecordRepository applicationrecordRepository)
        {
            _applicationrecordRepository = applicationrecordRepository;
        }

        public async Task<ApplicationRecordModel> Handle(UpdateApplicationRecordCommand request, CancellationToken cancellationToken)
        {
            return await _applicationrecordRepository.UpdateAsync(request.model, cancellationToken);
        }
    }
}