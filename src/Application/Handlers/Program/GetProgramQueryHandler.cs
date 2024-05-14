using SO00000010.Application.Queries.Program;
using SO00000010.Domain.Contracts.ProgramContracts;

namespace SO00000010.Application.Handlers.Program
{
    public record GetProgramQueryHandler : IRequestHandler<GetProgramsQuery, IEnumerable<ProgramModel>>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramQueryHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IEnumerable<ProgramModel>> Handle(GetProgramsQuery request, CancellationToken cancellationToken)
        {
            return await _programRepository.GetAsync();
        }
    }
}