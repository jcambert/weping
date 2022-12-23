using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Clubs.Queries;
using WePing.SmartPing.Domain.Divisions.Queries;

namespace WePing.SmartPing.Spid.Domain.Clubs.Queries;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IGetClubQuery))]
public class GetClubQuery : IGetClubQuery
{
    public string Numero { get; set; }
}
