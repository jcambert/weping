using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IPipelineBehavior<BrowseJoueurSpidQuery, BrowseJoueurSpidResponse>))]
public class JoueurSpidValidator : IPipelineBehavior<BrowseJoueurSpidQuery, BrowseJoueurSpidResponse>
{



    public Task<BrowseJoueurSpidResponse> Handle(BrowseJoueurSpidQuery request, RequestHandlerDelegate<BrowseJoueurSpidResponse> next, CancellationToken cancellationToken)
    {
        
        if (request == null )
            throw new ArgumentException("You must specify a request");

        if (!(new string[] { "0", "1" }.Contains(request.Valid)))
            throw new ArgumentException("Valid must be either 0 or 1");
        return next();
       // return next(request, cancellationToken);
    }
}
