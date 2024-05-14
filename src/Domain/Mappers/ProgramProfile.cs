using SO00000010.Domain.Contracts.ProgramContracts;
using SO00000010.Domain.Entities;

namespace SO00000010.Domain.Mappers
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<CreateProgramModel, Program>().ReverseMap()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

            CreateMap<UpdateProgramModel, Program>().ReverseMap();

            CreateMap<ProgramModel, Program>().ReverseMap()
                .ForMember(dest => dest.ApplicationRecords, opt => opt.MapFrom(src => src.Applications))
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));
        }
    }
}