using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Parties.Queries;
using WePing.SmartPing.Spid.Domain.Parties.Queries;

namespace WePing.SmartPing.Spid.Handlers.Parties;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IPipelineBehavior<BrowsePartiesSpidQuery, BrowsePartiesSpidResponse>))]
public class PartiesSpidValidator : IPipelineBehavior<BrowsePartiesSpidQuery, BrowsePartiesSpidResponse>
{
    public Task<BrowsePartiesSpidResponse> Handle(BrowsePartiesSpidQuery request, RequestHandlerDelegate<BrowsePartiesSpidResponse> next, CancellationToken cancellationToken)
    {
        if (request == null || request.NumLic.IsNullOrEmpty())
            throw new ArgumentException("You must specify Licence");
        return next();
    }
}
