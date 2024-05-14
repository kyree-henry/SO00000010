using SO00000010.Application.Interfaces.Services;
using SO00000010.Domain.Contracts.AnswerContracts;
using SO00000010.Domain.Exceptions;

namespace SO00000010.Infrastructure.Data.Repositories
{
    internal class AnswerRepository : IAnswerRepository
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;
        public AnswerRepository(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnswerModel>> GetAsync()
        {
            IEnumerable<Answer>? answers = await _context.Answers.ToListAsync();
            return _mapper.Map<IEnumerable<AnswerModel>>(answers);
        }

        public async Task<AnswerModel> GetByIdAsync(Guid id)
        {
            Answer? answer = await _context.Answers.Include(a => a.Application).SingleOrDefaultAsync(a => a.Id == id);
            return answer is not null ? _mapper.Map<AnswerModel>(answer) : default!;
        }

        public async Task<AnswerModel> CreateAsync(CreateAnswerModel data, CancellationToken cancellationToken)
        {
            Answer answer = _mapper.Map<Answer>(data);
            _context.Answers.Add(answer);

            int result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? _mapper.Map<AnswerModel>(answer) : default!;
        }

        public async Task<AnswerModel> UpdateAsync(UpdateAnswerModel data, CancellationToken cancellationToken)
        {
            Answer answer = await _context.Answers.SingleOrDefaultAsync(a => a.Id == data.Id)
                            ?? throw new SO00000010Exception("Answer not found!");

            _mapper.Map(data, answer);
            _context.Answers.Update(answer);

            int result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? _mapper.Map<AnswerModel>(answer) : default!;
        }
    }
}
