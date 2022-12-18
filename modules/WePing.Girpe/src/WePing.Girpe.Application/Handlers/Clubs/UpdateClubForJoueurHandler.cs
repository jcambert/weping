using System;
using System.Linq;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Dto;

namespace WePing.Girpe.Handlers.Clubs;

public class UpdateClubForJoueurHandler : BaseHandler<UpdateClubForJoueurQuery, GetClubResponse>
{
    protected IRepository<Joueur, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Joueur, Guid>>();
 
    public UpdateClubForJoueurHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<GetClubResponse> Handle(UpdateClubForJoueurQuery request, CancellationToken cancellationToken)
    {
        var joueurRequest = ObjectMapper.Map<UpdateClubForJoueurQuery, GetJoueurQuery>(request);
        var joueurResp = await Mediator.Send(joueurRequest);

        var clubQuery = ObjectMapper.Map<JoueurDto, GetClubQuery>(joueurResp.Joueur);
        var resp = await Mediator.Send(clubQuery);


        joueurResp.Joueur.ClubId = resp.Club.Id;

        var joueur = ObjectMapper.Map<JoueurDto, Joueur>(joueurResp.Joueur);

        var queryable =await Repository.GetQueryableAsync();
        var joueurs = queryable.ToList();
        var q = from j in queryable where j.Id==joueurResp.Joueur.Id select  j ;
        var jj = q.FirstOrDefault();
        jj.ClubId = resp.Club.Id;

        //(await Repository.FindAsync(x=>x.Id==joueur.Id)).ClubId= resp.Club.Id;
        await Repository.UpdateAsync(jj, true, cancellationToken);

        return resp;

    }
}
