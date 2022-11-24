using AutoMapper;
using Volo.Abp.AutoMapper;
using WePing.Girpe.Clubs;
namespace WePing.Girpe;

public class GirpeApplicationAutoMapperProfile : Profile
{
    public GirpeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Club, ClubDto>();
        CreateMap<ClubDto, Club>()
            .ForMember(x=>x.ConcurrencyStamp,opt=>opt.Ignore())
            .ForMember(x => x.ExtraProperties, opt => opt.Ignore())
            ;

        CreateMap<SmartPing.Domain.Clubs.Dto.ClubDto, ClubDto>()
            .ForMember(x=>x.Id,opt=>opt.Ignore())
            .ForMember(x=>x.Identifiant,opt=>opt.MapFrom(src=>src.Id))
            .ForMember(x => x.NomSalle, opt => opt.Ignore())
            .ForMember(x => x.AdresseSalle1, opt => opt.Ignore())
            .ForMember(x => x.AdresseSalle2, opt => opt.Ignore())
            .ForMember(x => x.AdresseSalle3, opt => opt.Ignore())
            .ForMember(x => x.CodePostalSalle, opt => opt.Ignore())
            .ForMember(x => x.VilleSalle, opt => opt.Ignore())
            .ForMember(x => x.Web, opt => opt.Ignore())
            .ForMember(x => x.NomCorrespondant, opt => opt.Ignore())
            .ForMember(x => x.PrenomCorrespondant, opt => opt.Ignore())
            .ForMember(x => x.MailCorrespondant, opt => opt.Ignore())
            .ForMember(x => x.TelephoneCorrespondant, opt => opt.Ignore())
            .ForMember(x => x.Latitude, opt => opt.Ignore())
            .ForMember(x => x.Longitude, opt => opt.Ignore())
            .IgnoreAuditedObjectProperties()
            ;
        
        CreateMap<SmartPing.Domain.ClubDetails.Dto.ClubDetailDto, ClubDto>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.Numero, opt => opt.Ignore())
            .ForMember(x => x.Identifiant, opt => opt.Ignore())
            .ForMember(x => x.Nom, opt => opt.Ignore())
            .ForMember(x => x.Validation, opt => opt.Ignore())
            .IgnoreAuditedObjectProperties()
            ;

        CreateMap<CreateUpdateClubDto, Club>().IgnoreAuditedObjectProperties().IgnoreAllPropertiesWithAnInaccessibleSetter();
    }
}
