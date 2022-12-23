using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace WePing.Girpe.Clubs.Queries;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBrowseClubQuery))]
public class BrowseClubQuery : IBrowseClubQuery
{
    public string Dep { get; set; }

    public string Code { get; set; }

    public string Ville { get; set; }

    public string Numero { get; set; }
    public int Number { get; set; }
}
