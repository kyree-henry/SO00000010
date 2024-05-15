using SO00000010.Application.Interfaces.Services;
using SO00000010.Domain.Contracts.ApplicationRecordContracts;
using SO00000010.Domain.Exceptions;

namespace SO00000010.Infrastructure.Data.Repositories
{
    internal class ApplicationRecordRepository : IApplicationRecordRepository
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;
        public ApplicationRecordRepository(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationRecordModel>> GetAsync()
        {
            IEnumerable<ApplicationRecord>? applicationrecords = await _context.Applications.ToListAsync();
            return _mapper.Map<IEnumerable<ApplicationRecordModel>>(applicationrecords);
        }

        public async Task<ApplicationRecordModel> GetByIdAsync(Guid id)
        {
            ApplicationRecord? applicationrecord = await _context.Applications.SingleOrDefaultAsync(a => a.Id == id);
            return applicationrecord is not null ? _mapper.Map<ApplicationRecordModel>(applicationrecord) : default!;
        }

        public async Task<ApplicationRecordModel> CreateAsync(CreateApplicationRecordModel data, CancellationToken cancellationToken)
        {
            ApplicationRecord applicationrecord = _mapper.Map<ApplicationRecord>(data);
            _context.Applications.Add(applicationrecord);

            int result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? _mapper.Map<ApplicationRecordModel>(applicationrecord) : default!;
        }

        public async Task<ApplicationRecordModel> UpdateAsync(UpdateApplicationRecordModel data, CancellationToken cancellationToken)
        {
            ApplicationRecord applicationrecord = await _context.Applications.SingleOrDefaultAsync(a => a.Id == data.Id)
                            ?? throw new SO00000010Exception("Application not found!");

            _mapper.Map(data, applicationrecord);
            _context.Applications.Update(applicationrecord);

            int result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0 ? _mapper.Map<ApplicationRecordModel>(applicationrecord) : default!;
        }
    }
}