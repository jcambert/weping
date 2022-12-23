using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.Girpe.Joueurs.Queries;

namespace WePing.Girpe.Joueurs;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBrowseJoueurQuery))]
public class BrowseJoueurQuery : IBrowseJoueurQuery
{
    public Guid ClubId { get; set; }
    public string ClubNumero { get; set; }
    public bool ForceLoadClubIfNotSet { get; set; }
}
