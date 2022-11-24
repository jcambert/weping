using AutoMapper;
using WePing.SmartPing.Domain.ClubDetails.Domain;
using WePing.SmartPing.Domain.ClubDetails.Dto;
using WePing.SmartPing.Domain.Clubs.Domain;
using WePing.SmartPing.Domain.Clubs.Dto;
using WePing.SmartPing.Domain.Divisions.Domain;
using WePing.SmartPing.Domain.Divisions.Dto;
using WePing.SmartPing.Domain.Epreuves.Domain;
using WePing.SmartPing.Domain.Epreuves.Dto;
using WePing.SmartPing.Domain.Organismes.Domain;
using WePing.SmartPing.Domain.Organismes.Dto;

namespace WePing.SmartPing;

public class SmartPingApplicationAutoMapperProfile : Profile
{
    public SmartPingApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        this.CreateMap<Club, ClubDto>();
        this.CreateMap<ClubDetail, ClubDetailDto>();
        this.CreateMap<Organisme, OrganismeDto>();
        this.CreateMap<Epreuve, EpreuveDto>();
        this.CreateMap<Division, DivisionDto>();
    }
}
