using SO00000010.Domain.Contracts.ProgramContracts;

namespace SO00000010.Application.Commands.Program
{
    public record CreateProgramCommand(CreateProgramModel model) : IRequest<ProgramModel>;
}