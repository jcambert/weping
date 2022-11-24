

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace WePing.SmartPing.Spid;

[Area(SmartPingRemoteServiceConsts.ModuleName)]
[RemoteService(Name = SmartPingRemoteServiceConsts.RemoteServiceName)]
[Route("api/SmartPing/spid")]
public class SpidAuthorizationController : SmartPingController, ISpidAuthorizationBuilderAppService
{

    public ISpidAuthorizationBuilderAppService Service { get; init; }
    public SpidAuthorizationController(ISpidAuthorizationBuilderAppService service) =>(Service)=(service);

    [HttpGet("auth")]
    public Task<SpidAuthorization> GetAsync()=>Service.GetAsync();

}
