using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class JoueurDetailSpidValidator : IPipelineBehavior<GetJoueurDetailSpidQuery, GetJoueurDetailSpidResponse>
{
    public JoueurDetailSpidValidator()
    {
    }

    public ValueTask<GetJoueurDetailSpidResponse> Handle(GetJoueurDetailSpidQuery request, CancellationToken cancellationToken, MessageHandlerDelegate<GetJoueurDetailSpidQuery, GetJoueurDetailSpidResponse> next)
    {
        if (request == null || string.IsNullOrEmpty(request.Licence) )
            throw new ArgumentException("You must specify Licence");
        return next(request, cancellationToken);

    }
}
