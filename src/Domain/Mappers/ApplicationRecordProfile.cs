using SO00000010.Domain.Contracts.ApplicationRecordContracts;
using SO00000010.Domain.Contracts.ProgramContracts;
using SO00000010.Domain.Entities;

namespace SO00000010.Domain.Mappers
{
    public class ApplicationRecordProfile : Profile
    {
        public ApplicationRecordProfile()
        {
            CreateMap<ApplicationRecordModel, ApplicationRecord>().ReverseMap();

            CreateMap<CreateApplicationRecordModel, ApplicationRecord>().ReverseMap();
            CreateMap<UpdateApplicationRecordModel, ApplicationRecord>().ReverseMap();

            CreateMap<CreateProgramAndApplicationModel, ApplicationRecord>();
        }
    }
}