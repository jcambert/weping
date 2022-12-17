using System;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Dto;
using WePing.Girpe.Joueurs.Queries;

namespace WePing.Girpe.Handlers.Clubs;

public class UpdateClubForJoueurHandler : BaseHandler<IUpdateClubForJoueurQuery, GetClubResponse>
{
    protected IRepository<Joueur, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Joueur, Guid>>();
 
    public UpdateClubForJoueurHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<GetClubResponse> Handle(IUpdateClubForJoueurQuery request, CancellationToken cancellationToken)
    {
        var joueurRequest = ObjectMapper.Map<IUpdateClubForJoueurQuery, IGetJoueurQuery>(request);
        var joueurResp = await Mediator.Send(joueurRequest);

        var clubQuery = ObjectMapper.Map<JoueurDto, GetClubQuery>(joueurResp.Joueur);
        var resp = await Mediator.Send(clubQuery);


        joueurResp.Joueur.ClubId = resp.Club.Id;

        var joueur = ObjectMapper.Map<JoueurDto, Joueur>(joueurResp.Joueur);
        await Repository.UpdateAsync(joueur,false, cancellationToken);

        return resp;

    }
}
