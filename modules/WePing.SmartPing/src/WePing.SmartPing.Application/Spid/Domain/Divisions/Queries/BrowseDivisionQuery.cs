using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Domain.Divisions.Queries;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBrowseDivisionQuery))]
public class BrowseDivisionQuery : IBrowseDivisionQuery
{
    public string Organisme { get; set; }
    public string Epreuve { get; set; }
    public string Type { get; set; }
}
