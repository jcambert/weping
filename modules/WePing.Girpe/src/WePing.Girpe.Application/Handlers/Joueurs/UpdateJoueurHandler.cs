using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Queries;
using WePing.Girpe.Joueurs.Queries.Impl;
using WePing.Girpe.Services;

namespace WePing.Girpe.Handlers.Joueurs;

public class UpdateJoueurHandler : BaseHandler<UpdateJoueurQuery, UpdateJoueurResponse>
{
    protected UpdateJoueurFromSpidDomainService UpdateJoueurService => GetRequiredService<UpdateJoueurFromSpidDomainService>();
    protected IRepository<Joueur, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Joueur, Guid>>();
    public UpdateJoueurHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<UpdateJoueurResponse> Handle(UpdateJoueurQuery request, CancellationToken cancellationToken)
    {
        var queryable = await Repository.GetQueryableAsync();

        var mappedRequest = ObjectMapper.Map<UpdateJoueurQuery, Joueur>(request);
        var query = queryable.Filter(mappedRequest);

        var joueur = await AsyncExecuter.FirstOrDefaultAsync(query);
        //JoueurDto joueurDto=new();
        bool from_db = joueur != null;
        if (joueur != null && !string.IsNullOrEmpty(joueur.Licence))
        {
            //ObjectMapper.Map(joueur, joueurDto);
            await UpdateJoueurService.Update(joueur,request.DetailOptions,cancellationToken);
            //ObjectMapper.Map(joueurDto, joueur);
            await Repository.UpdateAsync(joueur,true,cancellationToken);

            
        }
        
        return new UpdateJoueurResponse(joueur) { FromDatabase = from_db };
    }
}