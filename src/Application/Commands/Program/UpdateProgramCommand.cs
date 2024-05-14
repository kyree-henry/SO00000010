using SO00000010.Domain.Contracts.ProgramContracts;

namespace SO00000010.Application.Commands.Program
{
    public record UpdateProgramCommand(UpdateProgramModel model) : IRequest<ProgramModel>;
}