using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
using WePing.SmartPing.Domain.Parties.Domain;
using WePing.SmartPing.Domain.Parties.Dto;
using WePing.SmartPing.Domain.Parties.Queries;

namespace WePing.SmartPing.Spid;

public class SpidAppService : SmartPingAppService, ISpidAppService
{


    public IMediator Mediator => LazyServiceProvider.LazyGetRequiredService<IMediator>();
    public SpidAppService() { }

    protected TDestination Map<TSource, TDestination>(TSource source) => ObjectMapper.Map<TSource, TDestination>(source);
    public async Task<string> GetQuery(ISpidRequestQuery query, CancellationToken cancellationToken = default)
    {
        SpidRequestResponse res = await Mediator.Send(query, cancellationToken);
        return res.response;
    }

    public virtual async Task<List<ClubDto>> GetClubs(IBrowseClubsQuery query, CancellationToken cancellationToken = default)
        => Map<List<Club>, List<ClubDto>>((await Mediator.Send(query, cancellationToken)).clubs);


    public async Task<ClubDto> GetClub(IGetClubQuery query, CancellationToken cancellationToken = default)
        => Map<Club, ClubDto>((await Mediator.Send(query, cancellationToken)).Club);


    public async Task<ClubDetailDto> GetClubDetail(IGetClubDetailQuery query, CancellationToken cancellationToken = default)
         => Map<ClubDetail, ClubDetailDto>((await Mediator.Send(query, cancellationToken)).Club);


    public async Task<List<OrganismeDto>> GetOrganismes(IBrowseOrganismeQuery query, CancellationToken cancellationToken = default)
        => Map<List<Organisme>, List<OrganismeDto>>((await Mediator.Send(query, cancellationToken)).Organismes);


    public async Task<List<EpreuveDto>> GetEpreuves(IBrowseEpreuveQuery query, CancellationToken cancellationToken = default)
        => Map<List<Epreuve>, List<EpreuveDto>>((await Mediator.Send(query, cancellationToken)).Epreuves);

    public async Task<List<DivisionDto>> GetDivisions(IBrowseDivisionQuery query, CancellationToken cancellationToken = default)
        => Map<List<Division>, List<DivisionDto>>((await Mediator.Send(query, cancellationToken)).Divisions);

    public async Task<List<JoueurClassementDto>> GetJoueursClassement(IBrowseJoueurClassementQuery query, CancellationToken cancellationToken = default)
        => Map<List<JoueurClassement>, List<JoueurClassementDto>>((await Mediator.Send(query, cancellationToken)).Joueurs);


    public async Task<List<JoueurSpidDto>> GetJoueursSpid(IBrowseJoueurSpidQuery query, CancellationToken cancellationToken = default)
         => Map<List<JoueurSpid>, List<JoueurSpidDto>>((await Mediator.Send(query, cancellationToken)).Joueurs);


    public async Task<JoueurDetailClassementDto> GetJoueurDetail(IGetJoueurDetailClassementQuery query, CancellationToken cancellationToken = default)
        => Map<JoueurDetailClassement, JoueurDetailClassementDto>((await Mediator.Send(query, cancellationToken)).Joueur);
   

    public async Task<JoueurDetailSpidDto> GetJoueurDetail(IGetJoueurDetailSpidQuery query, CancellationToken cancellationToken = default)
        => Map<JoueurDetailSpid, JoueurDetailSpidDto>((await Mediator.Send(query, cancellationToken)).Joueur);


    public async Task<JoueurDetailSpidClaDto> GetJoueurDetail(IGetJoueurDetailSpidClaQuery query, CancellationToken cancellationToken = default)
        => Map<JoueurDetailSpidCla, JoueurDetailSpidClaDto>((await Mediator.Send(query, cancellationToken)).Joueur);


    public async Task<List<JoueurDetailSpidClaDto>> GetJoueursDetail(IBrowseJoueurDetailSpidClaQuery query, CancellationToken cancellationToken = default)
        => Map<List<JoueurDetailSpidCla>, List<JoueurDetailSpidClaDto>>((await Mediator.Send(query, cancellationToken)).Joueurs);


    public async Task<List<PartiesSpidDto>> BrowseJoueurParties(IBrowsePartiesSpidQuery query,CancellationToken cancellationToken=default)
         => Map<List<PartiesSpid>, List<PartiesSpidDto>>((await Mediator.Send(query,cancellationToken)).Parties);
 
}
