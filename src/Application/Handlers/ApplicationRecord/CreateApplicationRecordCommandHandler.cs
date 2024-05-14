using SO00000010.Application.Commands.ApplicationRecord;
using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Application.Handlers.ApplicationRecord
{
    public record CreateApplicationRecordCommandHandler : IRequestHandler<CreateApplicationRecordCommand, ApplicationRecordModel>
    {
        private readonly IApplicationRecordRepository _applicationrecordRepository;

        public CreateApplicationRecordCommandHandler(IApplicationRecordRepository applicationrecordRepository)
        {
            _applicationrecordRepository = applicationrecordRepository;
        }

        public async Task<ApplicationRecordModel> Handle(CreateApplicationRecordCommand request, CancellationToken cancellationToken)
        {
            return await _applicationrecordRepository.CreateAsync(request.model, cancellationToken);
        }
    }
}