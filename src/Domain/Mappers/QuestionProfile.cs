using Newtonsoft.Json;
using SO00000010.Domain.Contracts.QuestionContracts;
using SO00000010.Domain.Entities;

namespace SO00000010.Domain.Mappers
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionModel, Question>().ReverseMap();

            CreateMap<UpdateQuestionModel, Question>().ReverseMap();

            CreateMap<CreateQuestionModel, Question>()
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Choices)))
                .ReverseMap()
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.ListOfChoices));
        }
    }
}