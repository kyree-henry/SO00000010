using SO00000010.Application.Commands.Program;
using SO00000010.Domain.Contracts.ProgramContracts;

namespace SO00000010.Application.Handlers.Program
{
    public record UpdateProgramCommandHandler : IRequestHandler<UpdateProgramCommand, ProgramModel>
    {
        private readonly IProgramRepository _programRepository;

        public UpdateProgramCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<ProgramModel> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            return await _programRepository.UpdateAsync(request.model, cancellationToken);
        }
    }
}