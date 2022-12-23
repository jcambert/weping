using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IPipelineBehavior<GetJoueurDetailSpidQuery, GetJoueurDetailSpidResponse>))]
public class JoueurDetailSpidValidator : IPipelineBehavior<GetJoueurDetailSpidQuery, GetJoueurDetailSpidResponse>
{
    public JoueurDetailSpidValidator()
    {
    }


    public Task<GetJoueurDetailSpidResponse> Handle(GetJoueurDetailSpidQuery request, RequestHandlerDelegate<GetJoueurDetailSpidResponse> next, CancellationToken cancellationToken)
    {
        if (request == null || string.IsNullOrEmpty(request.Licence) )
            throw new ArgumentException("You must specify Licence");
        return next();
       // return next(request, cancellationToken);
        //throw new NotImplementedException();
    }
}
