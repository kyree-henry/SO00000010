using AutoMapper;
using SO00000010.Application.Commands.Program;

namespace SO00000010.Application.Handlers.Program
{
    public record CreateProgramAndApplicationCommandHandler : IRequestHandler<CreateProgramAndApplicationCommand, bool>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;
        public CreateProgramAndApplicationCommandHandler(IProgramRepository programRepository, IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateProgramAndApplicationCommand request, CancellationToken cancellationToken)
        {
            return await _programRepository.CreateProgramAndApplication(request.model, cancellationToken);
        }
    }
}