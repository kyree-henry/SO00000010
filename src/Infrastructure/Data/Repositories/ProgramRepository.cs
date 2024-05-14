using SO00000010.Application.Interfaces.Services;
using SO00000010.Domain.Contracts.ProgramContracts;
using SO00000010.Domain.Exceptions;

namespace SO00000010.Infrastructure.Data.Repositories
{
    internal class ProgramRepository : IProgramRepository
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;
        public ProgramRepository(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ProgramModel>> GetAsync()
        {
            IEnumerable<Program>? programs = await _context.Programs.ToListAsync();
            return _mapper.Map<IEnumerable<ProgramModel>>(programs);
        }

        public async Task<ProgramModel> GetByIdAsync(Guid id)
        {
            Program? program = await _context.Programs.Include(a => a.Questions).SingleOrDefaultAsync(a => a.Id == id);
            return program is not null ? _mapper.Map<ProgramModel>(program) : default!;
        }

        public async Task<ProgramModel> CreateAsync(CreateProgramModel data, CancellationToken cancellationToken)
        {
            Program program = _mapper.Map<Program>(data);
            _context.Programs.Add(program);

            int result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? _mapper.Map<ProgramModel>(program) : default!;
        }

        public async Task<ProgramModel> UpdateAsync(UpdateProgramModel data, CancellationToken cancellationToken)
        {
            Program program = await _context.Programs.Include(a => a.Questions).SingleOrDefaultAsync(a => a.Id == data.Id) 
                            ?? throw new SO00000010Exception("Program not found!");

            _mapper.Map(data, program);
            _context.Programs.Update(program);

            int result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? _mapper.Map<ProgramModel>(program) : default!;
        }
    }
}