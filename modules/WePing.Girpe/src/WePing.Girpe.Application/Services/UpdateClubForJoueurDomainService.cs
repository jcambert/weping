using System.Threading;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain;
using WePing.Girpe.Joueurs;

namespace WePing.Girpe.Services;

public class UpdateClubForJoueurDomainService : GirpeDomainService
{
    //protected IRepository<Joueur, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Joueur, Guid>>();
    public async Task<Club> UpdateClub(Joueur joueur, CancellationToken cancellationToken=default)
    {
        if (joueur == null || Guid.Empty==joueur.Id || string.IsNullOrEmpty( joueur.Licence))
            return default;

        var clubQuery = ObjectMapper.Map<Joueur, GetClubQuery>(joueur);
        var clubResp = await Mediator.Send(clubQuery);

        joueur.ClubId = clubResp.Club.Id;

        //var j=ObjectMapper.Map<JoueurDto, Joueur>( joueur);
        //await Repository.UpdateAsync(j, true, cancellationToken);
        return clubResp.Club;
    }
}
