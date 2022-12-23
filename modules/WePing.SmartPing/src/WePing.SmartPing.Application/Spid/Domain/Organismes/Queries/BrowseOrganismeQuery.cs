using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Organismes.Queries;

namespace WePing.SmartPing.Spid.Domain.Organismes.Queries;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBrowseOrganismeQuery))]
public class BrowseOrganismeQuery : IBrowseOrganismeQuery
{
    public string Type { get; set; }

}
