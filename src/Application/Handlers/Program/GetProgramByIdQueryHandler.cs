using SO00000010.Application.Queries.Program;
using SO00000010.Domain.Contracts.ProgramContracts;

namespace SO00000010.Application.Handlers.Program
{
    public record GetProgramByIdQueryHandler : IRequestHandler<GetProgramByIdQuery, ProgramModel>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramByIdQueryHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<ProgramModel> Handle(GetProgramByIdQuery request, CancellationToken cancellationToken)
        {
            return await _programRepository.GetByIdAsync(request.id);
        }
    }
}