using SO00000010.Domain.Contracts.ProgramContracts;
using SO00000010.Domain.Entities;

namespace SO00000010.Domain.Mappers
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<UpdateProgramModel, Program>().ReverseMap()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

            CreateMap<CreateProgramModel, Program>().ReverseMap();

            CreateMap<Program, ProgramModel>().ReverseMap()
                .ForMember(dest => dest.Applications, opt => opt.MapFrom(src => src.ApplicationRecords));

            CreateMap<CreateProgramAndApplicationModel, Program>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));
        }
    }
}