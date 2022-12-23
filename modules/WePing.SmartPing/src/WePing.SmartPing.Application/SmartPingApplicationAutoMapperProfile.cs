using AutoMapper;
using System.Collections.Generic;
using WePing.SmartPing.Domain.ClubDetails.Domain;
using WePing.SmartPing.Domain.ClubDetails.Dto;
using WePing.SmartPing.Domain.Clubs.Domain;
using WePing.SmartPing.Domain.Clubs.Dto;
using WePing.SmartPing.Domain.Divisions.Domain;
using WePing.SmartPing.Domain.Divisions.Dto;
using WePing.SmartPing.Domain.Epreuves.Domain;
using WePing.SmartPing.Domain.Epreuves.Dto;
using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Domain.Joueurs.Dto;
using WePing.SmartPing.Domain.Organismes.Domain;
using WePing.SmartPing.Domain.Organismes.Dto;
using WePing.SmartPing.Domain.Parties.Domain;
using WePing.SmartPing.Domain.Parties.Dto;

namespace WePing.SmartPing;

public class SmartPingApplicationAutoMapperProfile : Profile
{
    public SmartPingApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Club, ClubDto>();
        CreateMap<ClubDetail, ClubDetailDto>();
        CreateMap<Organisme, OrganismeDto>();
        CreateMap<Epreuve, EpreuveDto>();
        CreateMap<Division, DivisionDto>();
        CreateMap<JoueurClassement, JoueurClassementDto>();
        CreateMap<JoueurDetailClassement, JoueurDetailClassementDto>();
        CreateMap<JoueurDetailSpid, JoueurDetailSpidDto>();
        CreateMap<JoueurDetailSpidCla, JoueurDetailSpidClaDto>();
        CreateMap<JoueurSpid, JoueurSpidDto>();
        CreateMap<PartiesSpid, PartiesSpidDto>();
    }
}
