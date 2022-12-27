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
    public async  Task<BrowseClubResponseDto> GetAllAsync([FromQuery] BrowseClubQuery query) 
        =>ObjectMapper.Map< BrowseClubResponse,BrowseClubResponseDto>(await Service.GetAllAsync(query));


    [HttpGet("by_number")]
    public async Task<GetClubResponseDto> GetAsync([FromQuery] GetClubQuery query)
        =>  ObjectMapper.Map< GetClubResponse,GetClubResponseDto>(await Service.GetAsync(query));

    [HttpGet("update_for_joueur")]
    public async Task<UpdateClubForJoueurResponseDto> UpdateForJoueur([FromQuery] UpdateClubForJoueurQuery query) 
        => ObjectMapper.Map< UpdateClubForJoueurResponse,UpdateClubForJoueurResponseDto>(await  Service.UpdateForJoueur(query));
}

