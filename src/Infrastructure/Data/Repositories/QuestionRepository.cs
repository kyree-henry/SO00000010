using SO00000010.Application.Interfaces.Services;
using SO00000010.Domain.Contracts.QuestionContracts;
using SO00000010.Domain.Exceptions;

namespace SO00000010.Infrastructure.Data.Repositories
{
    internal class QuestionRepository : IQuestionRepository
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;
        public QuestionRepository(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionModel>> GetAsync()
        {
            IEnumerable<Question>? questions = await _context.Questions.ToListAsync();
            return _mapper.Map<IEnumerable<QuestionModel>>(questions);
        }

        public async Task<QuestionModel> GetByIdAsync(Guid id)
        {
            Question? question = await _context.Questions.SingleOrDefaultAsync(a => a.Id == id);
            return question is not null ? _mapper.Map<QuestionModel>(question) : default!;
        }

        public async Task<QuestionModel> CreateAsync(CreateQuestionModel data, CancellationToken cancellationToken)
        {
            Question question = _mapper.Map<Question>(data);
            _context.Questions.Add(question);

            int result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? _mapper.Map<QuestionModel>(question) : default!;
        }

        public async Task<QuestionModel> UpdateAsync(UpdateQuestionModel data, CancellationToken cancellationToken)
        {
            Question question = await _context.Questions.SingleOrDefaultAsync(a => a.Id == data.Id)
                            ?? throw new SO00000010Exception("Question not found!");

            _mapper.Map(data, question);
            _context.Questions.Update(question);

            int result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? _mapper.Map<QuestionModel>(question) : default!;
        }
    }
}