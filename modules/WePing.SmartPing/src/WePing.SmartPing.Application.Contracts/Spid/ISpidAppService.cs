
using WePing.SmartPing.Domain.ClubDetails.Dto;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using WePing.SmartPing.Domain.Clubs.Dto;
using WePing.SmartPing.Domain.Clubs.Queries;
using WePing.SmartPing.Domain.Divisions.Dto;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Domain.Epreuves.Dto;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Domain.Organismes.Dto;
using WePing.SmartPing.Domain.Organismes.Queries;

namespace WePing.SmartPing.Spid;

public interface ISpidAppService:IApplicationService
{
    Task<List<ClubDto>> GetClubs(IBrowseClubsQuery query);

    Task<ClubDto> GetClub(IGetClubQuery query);

    Task<ClubDetailDto> GetClubDetail(IGetClubDetailQuery query);

    Task<List<OrganismeDto>> GetOrganismes(IBrowseOrganismeQuery query);

    Task<List<EpreuveDto>> GetEpreuves(IBrowseEpreuveQuery query);

    Task<List<DivisionDto>> GetDivisions(IBrowseDivisionQuery query);
}
