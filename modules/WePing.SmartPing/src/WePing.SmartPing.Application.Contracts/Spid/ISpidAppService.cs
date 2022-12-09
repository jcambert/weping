

using WePing.SmartPing.Domain.ClubDetails.Dto;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using WePing.SmartPing.Domain.Clubs.Dto;
using WePing.SmartPing.Domain.Clubs.Queries;
using WePing.SmartPing.Domain.Divisions.Dto;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Domain.Epreuves.Dto;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Domain.Joueurs.Dto;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Domain.Organismes.Dto;
using WePing.SmartPing.Domain.Organismes.Queries;

namespace WePing.SmartPing.Spid;

public interface ISpidAppService:IApplicationService
{
    Task<string> GetQuery(ISpidRequestQuery query);

    Task<List<ClubDto>> GetClubs(IBrowseClubsQuery query);

    Task<ClubDto> GetClub(IGetClubQuery query);

    Task<ClubDetailDto> GetClubDetail(IGetClubDetailQuery query);

    Task<List<OrganismeDto>> GetOrganismes(IBrowseOrganismeQuery query);

    Task<List<EpreuveDto>> GetEpreuves(IBrowseEpreuveQuery query);

    Task<List<DivisionDto>> GetDivisions(IBrowseDivisionQuery query);

    Task<List<JoueurClassementDto>> GetJoueursClassement(IBrowseJoueurClassementQuery query);

    Task<List<JoueurSpidDto>> GetJoueursSpid(IBrowseJoueurSpidQuery query);

    Task<JoueurDetailClassementDto> GetJoueurDetail(IGetJoueurDetailClassementQuery query);

    Task<JoueurDetailSpidDto> GetJoueurDetail(IGetJoueurDetailSpidQuery query);

    Task<JoueurDetailSpidClaDto> GetJoueurDetail(IGetJoueurDetailSpidClaQuery query);

    Task<List<JoueurDetailSpidClaDto>> GetJoueursDetail(IBrowseJoueurDetailSpidClaQuery query);
}
