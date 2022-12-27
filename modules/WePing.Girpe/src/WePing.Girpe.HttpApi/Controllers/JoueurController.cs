using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.ObjectMapping;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Dto;
using WePing.Girpe.Joueurs.Queries;
using WePing.SmartPing;

namespace WePing.Girpe.Controllers;
[Area(SmartPingRemoteServiceConsts.ModuleName)]
[RemoteService(Name = SmartPingRemoteServiceConsts.RemoteServiceName)]
[Route("api/girpe/joueur")]
public class JoueurController : GirpeController/*,IJoueurAppService*/
{
    public IJoueurAppService Service => LazyServiceProvider.LazyGetRequiredService<IJoueurAppService>();

    [HttpGet("by_licence")]
    public async Task<GetJoueurResponseDto> GetByLicence([FromQuery] GetJoueurQuery query)
        => ObjectMapper.Map<GetJoueurResponse, GetJoueurResponseDto>(await Service.GetByLicence(query));


    [HttpGet("for_club")]
    public async Task<BrowseJoueurResponseDto> GetForClub([FromQuery] BrowseJoueurQuery query)
        =>ObjectMapper.Map<BrowseJoueurResponse, BrowseJoueurResponseDto>(await Service.GetForClub(query));

 
}
