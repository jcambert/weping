using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Domain.Organismes.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Organismes.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class JoueurClassementValidator : IPipelineBehavior<BrowseJoueurClassementQuery, BrowseJoueurClassementResponse>
{
    public JoueurClassementValidator()
    {
    }

    public ValueTask<BrowseJoueurClassementResponse> Handle(BrowseJoueurClassementQuery request, CancellationToken cancellationToken, MessageHandlerDelegate<BrowseJoueurClassementQuery, BrowseJoueurClassementResponse> next)
    {
        if (request == null || string.IsNullOrEmpty(request.Club) && string.IsNullOrEmpty(request.Nom))
            throw new ArgumentException("You must specify NumeroClub or Nom");
        return next(request, cancellationToken);

    }
}
