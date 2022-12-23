
using System.Threading.Tasks;
using WePing.Girpe.Clubs;
using WePing.Girpe.Clubs.Queries;

namespace WePing.Girpe.Services;

public class ClubAppService :
        GirpeAppService,
        IClubAppService
{


    public async Task<GetClubResponse> GetAsync(IGetClubQuery query)
        => await Mediator.Send(query);

    public async Task<BrowseClubResponse> GetAllAsync(IBrowseClubQuery query)
        => await Mediator.Send(query);

    public async Task<UpdateClubForJoueurResponse> UpdateForJoueur(IUpdateClubForJoueurQuery query)
        => await Mediator.Send(query);
}
