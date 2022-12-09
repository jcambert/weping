using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using WePing.Girpe.Clubs;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Queries;
using WePing.SmartPing;

namespace WePing.Girpe.Controllers;
[Area(SmartPingRemoteServiceConsts.ModuleName)]
[RemoteService(Name = SmartPingRemoteServiceConsts.RemoteServiceName)]
[Route("api/girpe/joueur")]
public class JoueurController:GirpeController/*,IJoueurAppService*/
{
    public IJoueurAppService Service => LazyServiceProvider.LazyGetRequiredService<IJoueurAppService>();

    [HttpGet("by_licence")]

    public Task<GetJoueurResponse> GetByLicence([FromQuery] GetJoueurQuery query) => Service.GetByLicence(query);

    [HttpGet("for_club")]
    public Task<BrowseJoueurResponse> GetForClub([FromQuery] BrowseJoueurQuery query)=>Service.GetForClub(query);
}
