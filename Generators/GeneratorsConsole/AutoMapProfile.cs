using AutoMapper;
using GeneratorsData;

namespace GeneratorsConsole;

public class AutoMapProfile:Profile
{
    public AutoMapProfile()
    {
        CreateMap<GetQuery, Dto>()
            .ForMember(x=>x.Identifiant,opt=>opt.MapFrom(x=>x.Identifiant))
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
            ;
    }
}
