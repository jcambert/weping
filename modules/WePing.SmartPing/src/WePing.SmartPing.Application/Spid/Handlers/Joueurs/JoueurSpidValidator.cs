using System.Linq;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class JoueurSpidValidator : IPipelineBehavior<BrowseJoueurSpidQuery, BrowseJoueurSpidResponse>
{

    public ValueTask<BrowseJoueurSpidResponse> Handle(BrowseJoueurSpidQuery request, CancellationToken cancellationToken, MessageHandlerDelegate<BrowseJoueurSpidQuery, BrowseJoueurSpidResponse> next)
    {
        if (request == null )
            throw new ArgumentException("You must specify a request");

        if (!(new string[] { "0", "1" }.Contains(request.Valid)))
            throw new ArgumentException("Valid must be either 0 or 1");
        return next(request, cancellationToken);
    }
}
