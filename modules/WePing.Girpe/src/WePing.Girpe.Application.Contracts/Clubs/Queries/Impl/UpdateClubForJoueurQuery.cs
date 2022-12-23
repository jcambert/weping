using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace WePing.Girpe.Clubs.Queries;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IUpdateClubForJoueurQuery))]
public class UpdateClubForJoueurQuery : IUpdateClubForJoueurQuery
{
    public string Licence { get; set; }
}
