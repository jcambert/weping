using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class JoueurDetailClassementValidator : IPipelineBehavior<GetJoueurDetailClassementQuery, GetJoueurDetailClassementResponse>
{
    public JoueurDetailClassementValidator()
    {
    }

    public ValueTask<GetJoueurDetailClassementResponse> Handle(GetJoueurDetailClassementQuery request, CancellationToken cancellationToken, MessageHandlerDelegate<GetJoueurDetailClassementQuery, GetJoueurDetailClassementResponse> next)
    {
        if (request == null || string.IsNullOrEmpty(request.Licence) )
            throw new ArgumentException("You must specify Licence");
        return next(request, cancellationToken);

    }
}
