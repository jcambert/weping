using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Parties.Queries;

namespace WePing.SmartPing.Spid.Domain.Parties.Queries;

[Dependency(ServiceLifetime.Transient),ExposeServices(typeof(IBrowsePartiesSpidQuery))]
public class BrowsePartiesSpidQuery: IBrowsePartiesSpidQuery
{
    public string NumLic { get; set; }
}
