using System.Linq;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Dto;
using WePing.Girpe.Services;

namespace WePing.Girpe.Handlers.Clubs;

public class UpdateClubForJoueurHandler : BaseHandler<UpdateClubForJoueurQuery, UpdateClubForJoueurResponse>
{
    public UpdateClubForJoueurDomainService UpdateService => GetRequiredService<UpdateClubForJoueurDomainService>();
    protected IRepository<Joueur, Guid> Repository => GetRequiredService<IRepository<Joueur, Guid>>();

    public UpdateClubForJoueurHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<UpdateClubForJoueurResponse> Handle(UpdateClubForJoueurQuery request, CancellationToken cancellationToken)
    {
        var joueurRequest = ObjectMapper.Map<UpdateClubForJoueurQuery, GetJoueurQuery>(request);
        var joueurResp = await Mediator.Send(joueurRequest);
        var joueur = joueurResp.Joueur;
        var club=await UpdateService.Update(joueur, cancellationToken);
        var queryable = await Repository.GetQueryableAsync();
        var q = from j in queryable where j.Id == joueurResp.Joueur.Id select j;
        var jj = q.FirstOrDefault();

        joueurResp.Joueur.ClubId = club.Id;

        ObjectMapper.Map<JoueurDto, Joueur>(joueurResp.Joueur, jj);

        await Repository.UpdateAsync(jj, true, cancellationToken);
        /*
        var clubQuery = ObjectMapper.Map<JoueurDto, GetClubQuery>(joueurResp.Joueur);
        var clubResp = await Mediator.Send(clubQuery);



        var queryable = await Repository.GetQueryableAsync();
        var q = from j in queryable where j.Id == joueurResp.Joueur.Id select j;
        var joueur = q.FirstOrDefault();

        joueurResp.Joueur.ClubId = clubResp.Club.Id;

        ObjectMapper.Map<JoueurDto, Joueur>(joueurResp.Joueur, joueur);

        await Repository.UpdateAsync(joueur, true, cancellationToken);*/

        return new UpdateClubForJoueurResponse(club, joueur) { FromDatabase = true };

    }
}
