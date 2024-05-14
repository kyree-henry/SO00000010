using SO00000010.Application.Commands.Program;
using SO00000010.Domain.Contracts.ProgramContracts;

namespace SO00000010.Application.Handlers.Program
{
    public record CreateProgramCommandHandler : IRequestHandler<CreateProgramCommand, ProgramModel>
    {
        private readonly IProgramRepository _programRepository;

        public CreateProgramCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<ProgramModel> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {
            return await _programRepository.CreateAsync(request.model, cancellationToken);
        }
    }
}