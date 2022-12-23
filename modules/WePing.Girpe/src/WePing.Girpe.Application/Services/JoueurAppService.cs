using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Queries;

namespace WePing.Girpe.Services;

public class JoueurAppService : GirpeAppService,IJoueurAppService
{


    public async Task<GetJoueurResponse> GetByLicence(IGetJoueurQuery query)
   => await Mediator.Send(query);

    

    public async Task<BrowseJoueurResponse> GetForClub(IBrowseJoueurQuery query)
        => await Mediator.Send(query);

    public async Task<UpdateJoueurResponse> Update(IUpdateJoueurQuery query)
    => await Mediator.Send(query);
}
