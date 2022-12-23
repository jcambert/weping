using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using Volo.Abp.DependencyInjection;

namespace WePing.SmartPing.Domain.Clubs.Queries;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBrowseClubsQuery))]
public class BrowseClubsQuery:IBrowseClubsQuery
{
    [Default]
    [Description("Département")]
    public string Dep { get; set; }

    public string Code { get; set; }

    public string Ville { get; set; }

    public string Numero { get; set; }

}
