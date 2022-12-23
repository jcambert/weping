using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.Girpe.Joueurs.Queries;


namespace WePing.Girpe.Joueurs;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IGetJoueurQuery))]
public class GetJoueurQuery : IGetJoueurQuery
{
    public string Licence { get; set; }

    public bool ForceLoadClubIfNotSet { get; set; }
    public UpdateJoueurFromSpidOption DetailOptions { get; set; } = UpdateJoueurFromSpidOption.All;
}
