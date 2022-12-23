using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using WePing.Girpe.Clubs;
using WePing.Girpe.Clubs.Queries;
using WePing.SmartPing;
namespace WePing.Girpe.Controllers;

[Area(SmartPingRemoteServiceConsts.ModuleName)]
[RemoteService(Name = SmartPingRemoteServiceConsts.RemoteServiceName)]
[Route("api/girpe/club")]

public class ClubController : GirpeController/*, IClubAppService*/
{

    public IClubAppService Service => LazyServiceProvider.LazyGetRequiredService<IClubAppService>();
    
    public ClubController()
    {
        
    }


    [HttpGet("all")]
    public Task<BrowseClubResponse> GetAllAsync([FromQuery] BrowseClubQuery query) =>Service.GetAllAsync(query);


    [HttpGet("by_number")]
    public Task<GetClubResponse> GetAsync([FromQuery] GetClubQuery query)=> Service.GetAsync(query);

    [HttpGet("update_for_joueur")]
    public Task<UpdateClubForJoueurResponse> UpdateForJoueur([FromQuery] UpdateClubForJoueurQuery query) => Service.UpdateForJoueur(query);
}

