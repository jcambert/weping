using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Domain.Joueurs.Queries;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IGetJoueurDetailSpidClaQuery))]
public class GetJoueurDetailSpidClaQuery : IGetJoueurDetailSpidClaQuery
{
    ///<inheritdoc/>
    public string Licence { get; set; }
}
