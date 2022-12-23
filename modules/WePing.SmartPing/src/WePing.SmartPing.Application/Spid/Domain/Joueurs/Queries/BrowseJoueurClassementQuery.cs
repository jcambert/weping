using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Domain.Joueurs.Queries;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBrowseJoueurClassementQuery))]
public class BrowseJoueurClassementQuery : IBrowseJoueurClassementQuery
{
    public string Club { get; set ; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
}
