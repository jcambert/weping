using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using WePing.SmartPing.Domain.Clubs.Queries;

namespace WePing.SmartPing.Spid.Domain.ClubDetails.Queries;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IGetClubDetailQuery))]
public class GetClubDetailQuery:IGetClubDetailQuery
{
    public string Club { get; set; }
}
