using SO00000010.Domain.Contracts.ProgramContracts;

namespace SO00000010.Application.Queries.Program
{
    public record GetProgramByIdQuery(Guid id) : IRequest<ProgramModel>;
}