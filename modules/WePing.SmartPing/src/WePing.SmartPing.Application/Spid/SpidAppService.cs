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
using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Domain.Joueurs.Dto;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Domain.Organismes.Domain;
using WePing.SmartPing.Domain.Organismes.Dto;
using WePing.SmartPing.Domain.Organismes.Queries;

namespace WePing.SmartPing.Spid;

public class SpidAppService : SmartPingAppService, ISpidAppService
{


    public IMediator Mediator { get; init; }
    public SpidAppService(IMediator mediator) => (Mediator) = (mediator);

    public async Task<string> GetQuery(ISpidRequestQuery query)
    {
        SpidRequestResponse res = await Mediator.Send(query);
        return res.response;
    }

    public virtual async Task<List<ClubDto>> GetClubs(IBrowseClubsQuery query)
    {
        BrowseClubResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<List<Club>, List<ClubDto>>(resp.clubs);
        return result;
    }

    public async Task<ClubDto> GetClub(IGetClubQuery query)
    {
        GetClubResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<Club, ClubDto>(resp.Club);
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

    public async Task<List<JoueurClassementDto>> GetJoueursClassement(IBrowseJoueurClassementQuery query)
    {
        BrowseJoueurClassementResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<List<JoueurClassement>, List<JoueurClassementDto>>(resp.Joueurs);
        return result;
    }

    public async Task<List<JoueurSpidDto>> GetJoueursSpid(IBrowseJoueurSpidQuery query)
    {
        BrowseJoueurSpidResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<List<JoueurSpid>, List<JoueurSpidDto>>(resp.Joueurs);
        return result;
    }

    public async Task<JoueurDetailClassementDto> GetJoueurDetail(IGetJoueurDetailClassementQuery query)
    {
        GetJoueurDetailClassementResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<JoueurDetailClassement, JoueurDetailClassementDto>(resp.Joueur);
        return result;
    }

    public async Task<JoueurDetailSpidDto> GetJoueurDetail(IGetJoueurDetailSpidQuery query)
    {
        GetJoueurDetailSpidResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<JoueurDetailSpid, JoueurDetailSpidDto>(resp.Joueur);
        return result;
    }

    public async Task<JoueurDetailSpidClaDto> GetJoueurDetail(IGetJoueurDetailSpidClaQuery query)
    {
        GetJoueurDetailSpidClaResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<JoueurDetailSpidCla, JoueurDetailSpidClaDto>(resp.Joueur);
        return result;
    }

    public async Task<List<JoueurDetailSpidClaDto>> GetJoueursDetail(IBrowseJoueurDetailSpidClaQuery query)
    {
        BrowseJoueurDetailSpidClaResponse resp = await Mediator.Send(query);
        var result = ObjectMapper.Map<List<JoueurDetailSpidCla>, List<JoueurDetailSpidClaDto>>(resp.Joueurs);
        return result;
    }


}
