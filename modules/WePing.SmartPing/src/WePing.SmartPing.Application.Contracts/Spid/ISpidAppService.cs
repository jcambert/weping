

using System.Threading;
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
using WePing.SmartPing.Domain.Parties.Dto;
using WePing.SmartPing.Domain.Parties.Queries;

namespace WePing.SmartPing.Spid;

public interface ISpidAppService:IApplicationService
{
    Task<string> GetQuery(ISpidRequestQuery query, CancellationToken cancellationToken = default);

    Task<List<ClubDto>> GetClubs(IBrowseClubsQuery query, CancellationToken cancellationToken = default);

    Task<ClubDto> GetClub(IGetClubQuery query, CancellationToken cancellationToken = default);

    Task<ClubDetailDto> GetClubDetail(IGetClubDetailQuery query, CancellationToken cancellationToken = default);

    Task<List<OrganismeDto>> GetOrganismes(IBrowseOrganismeQuery query, CancellationToken cancellationToken = default);

    Task<List<EpreuveDto>> GetEpreuves(IBrowseEpreuveQuery query, CancellationToken cancellationToken = default);

    Task<List<DivisionDto>> GetDivisions(IBrowseDivisionQuery query, CancellationToken cancellationToken = default);

    Task<List<JoueurClassementDto>> GetJoueursClassement(IBrowseJoueurClassementQuery query, CancellationToken cancellationToken = default);

    Task<List<JoueurSpidDto>> GetJoueursSpid(IBrowseJoueurSpidQuery query, CancellationToken cancellationToken = default);

    Task<JoueurDetailClassementDto> GetJoueurDetail(IGetJoueurDetailClassementQuery query, CancellationToken cancellationToken = default);

    Task<JoueurDetailSpidDto> GetJoueurDetail(IGetJoueurDetailSpidQuery query, CancellationToken cancellationToken = default);

    Task<JoueurDetailSpidClaDto> GetJoueurDetail(IGetJoueurDetailSpidClaQuery query, CancellationToken cancellationToken = default);

    Task<List<JoueurDetailSpidClaDto>> GetJoueursDetail(IBrowseJoueurDetailSpidClaQuery query, CancellationToken cancellationToken = default);

    Task<List<PartiesSpidDto>> BrowseJoueurParties(IBrowsePartiesSpidQuery query, CancellationToken cancellationToken = default);
}
