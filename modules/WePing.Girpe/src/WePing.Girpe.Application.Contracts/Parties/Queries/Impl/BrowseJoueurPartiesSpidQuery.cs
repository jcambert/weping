using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace WePing.Girpe.Parties.Queries.Impl;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBrowseJoueurPartiesSpidQuery))]
public class BrowseJoueurPartiesSpidQuery : IBrowseJoueurPartiesSpidQuery
{
    public string Licence { get ; set ; }
}
