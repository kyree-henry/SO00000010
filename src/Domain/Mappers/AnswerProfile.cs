using SO00000010.Domain.Contracts.AnswerContracts;
using SO00000010.Domain.Entities;

namespace SO00000010.Domain.Mappers
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerModel, Answer>().ReverseMap();
            CreateMap<CreateAnswerModel, Answer>().ReverseMap();
            CreateMap<UpdateAnswerModel, Answer>().ReverseMap();
        }
    }
}