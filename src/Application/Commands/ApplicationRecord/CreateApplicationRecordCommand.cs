using SO00000010.Domain.Contracts.ApplicationRecordContracts;

namespace SO00000010.Application.Commands.ApplicationRecord
{
    public record CreateApplicationRecordCommand(CreateApplicationRecordModel model) : IRequest<ApplicationRecordModel>;
}