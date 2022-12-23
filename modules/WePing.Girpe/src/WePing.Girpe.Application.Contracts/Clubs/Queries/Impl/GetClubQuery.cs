using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace WePing.Girpe.Clubs.Queries;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IGetClubQuery))]
public class GetClubQuery : IGetClubQuery
{
    public string Numero { get; set; }
    public Guid Id { get; set; }
}
