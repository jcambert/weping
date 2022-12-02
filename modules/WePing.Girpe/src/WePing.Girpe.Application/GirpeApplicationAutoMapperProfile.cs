using AutoMapper;
using System.Collections.Generic;
using Volo.Abp.AutoMapper;
using WePing.Girpe.Clubs;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Domain;
using WePing.Girpe.Domain.Clubs.Queries;
using WePing.Girpe.Joueurs.Dto;
using WePing.SmartPing.Domain.Joueurs.Dto;
using SP_QUERY = WePing.SmartPing.Domain.Clubs.Queries;
namespace WePing.Girpe;

public class GirpeApplicationAutoMapperProfile : Profile
{
    public GirpeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Club, ClubDto>()
            .ForMember(x=>x.LastModificationTime,opt=>opt.Ignore())
            .ForMember(x => x.LastModifierId, opt => opt.Ignore())
            .ForMember(x => x.CreationTime, opt => opt.Ignore())
            .ForMember(x => x.CreatorId, opt => opt.Ignore())
            ;
        CreateMap<ClubDto, Club>()
            .ForMember(x=>x.Joueurs,opt=>opt.Ignore())  
            //.ForMember(x=>x.ConcurrencyStamp,opt=>opt.Ignore())
           // .ForMember(x => x.ExtraProperties, opt => opt.Ignore())
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
            .ForMember(x=>x.Joueurs, opt => opt.Ignore())
            .IgnoreAuditedObjectProperties()
            ;
        
        CreateMap<SmartPing.Domain.ClubDetails.Dto.ClubDetailDto, ClubDto>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.Numero, opt => opt.Ignore())
            .ForMember(x => x.Identifiant, opt => opt.Ignore())
            .ForMember(x => x.Nom, opt => opt.Ignore())
            .ForMember(x => x.Validation, opt => opt.Ignore())
            .ForMember(x=>x.Joueurs,opt=>opt.Ignore())
            .IgnoreAuditedObjectProperties()
            ;

        CreateMap<CreateUpdateClubDto, Club>()
            .ForMember(x=>x.Joueurs,opt=>opt.Ignore())
            /*.IgnoreAuditedObjectProperties()*/.IgnoreAllPropertiesWithAnInaccessibleSetter();

        CreateMap<Joueur, JoueurDto>()
            .ForMember(x=>x.NumeroClub,opt=>opt.MapFrom(x=>x.Club.Numero ?? string.Empty))
            .ForMember(x => x.NomClub, opt => opt.MapFrom(x => x.Club.Nom ?? string.Empty))
            ;

        CreateMap<JoueurDto, Joueur>()
            .Ignore(x=>x.Club)
            ;

        CreateMap<JoueurClassementDto, JoueurDto>()
            .Ignore(x=>x.Id)
            .Ignore(x=>x.ClubId)
            .Ignore(x=>x.LicenceId)
            .Ignore(x=>x.Sexe)
            .Ignore(x => x.Type)
            .Ignore(x => x.CertificatMedical)
            .Ignore(x => x.DateDeValidationDuCertificatMedical)
            .Ignore(x => x.Echelon)
            .Ignore(x => x.Place)
            .Ignore(x => x.CategorieAge)
            .Ignore(x => x.PointClassement)
            .Ignore(x => x.PointsMensuel)
            .Ignore(x => x.AncienPointsMensuel)
            .Ignore(x => x.PointsInitials)
            .Ignore(x => x.Mutation)
            .Ignore(x => x.Nationnalite)
            .Ignore(x => x.Arbitre)
            .Ignore(x => x.JugeArbitre)
            .Ignore(x => x.Tech)
            ;

        CreateMap<JoueurDetailSpidClaDto, JoueurDto>()
            .Ignore(x=>x.Id)
            .Ignore(x => x.ClubId)
            .Ignore(x=>x.Classement)
            ;

        CreateMap<BrowseClubQuery, SP_QUERY.BrowseClubsQuery>();

        
    }
}
