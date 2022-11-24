using System.Collections.Generic;
using WePing.SmartPing.Domain.ClubDetails.Domain;
using WePing.SmartPing.Domain.ClubDetails.Dto;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using WePing.SmartPing.Domain.Clubs.Domain;
using WePing.SmartPing.Domain.Clubs.Dto;
using WePing.SmartPing.Domain.Clubs.Queries;
using WePing.SmartPing.Domain.Divisions.Domain;
using WePing.SmartPing.Domain.Divisions.Dto;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Domain.Epreuves.Domain;
using WePing.SmartPing.Domain.Epreuves.Dto;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Domain.Organismes.Domain;
using WePing.SmartPing.Domain.Organismes.Dto;
using WePing.SmartPing.Domain.Organismes.Queries;

namespace WePing.SmartPing.Spid;

public class SpidAppService : SmartPingAppService, ISpidAppService
{


    public IMediator Mediator { get; init; }
    public SpidAppService(IMediator mediator) => (Mediator) = (mediator);

    public virtual async Task<List<ClubDto>> GetClubs(IBrowseClubsQuery query)
    {
        BrowseClubResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<List<Club>, List<ClubDto>>(resp.clubs);
        return result;
    }

    public async Task<ClubDto> GetClub(IGetClubQuery query)
    {
        GetClubResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<Club, ClubDto>(resp.club);
        return result;
    }

    public async Task<ClubDetailDto> GetClubDetail(IGetClubDetailQuery query)
    {
        GetClubDetailResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<ClubDetail, ClubDetailDto>(resp.club);
        return result;
    }

    public async Task<List<OrganismeDto>> GetOrganismes(IBrowseOrganismeQuery query)
    {
        BrowseOrganismeResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<List<Organisme>, List<OrganismeDto>>(resp.Organismes);
        return result;
    }

    public async Task<List<EpreuveDto>> GetEpreuves(IBrowseEpreuveQuery query)
    {
        BrowseEpreuveResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<List<Epreuve>, List<EpreuveDto>>(resp.Epreuves);
        return result;
    }

    public async Task<List<DivisionDto>> GetDivisions(IBrowseDivisionQuery query)
    {
        BrowseDivisionResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<List<Division>, List<DivisionDto>>(resp.Divisions);
        return result;
    }
}
