using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class JoueurClassementValidator : IPipelineBehavior<BrowseJoueurClassementQuery, BrowseJoueurClassementResponse>
{
    public JoueurClassementValidator()
    {
    }


    public Task<BrowseJoueurClassementResponse> Handle(BrowseJoueurClassementQuery request, RequestHandlerDelegate<BrowseJoueurClassementResponse> next, CancellationToken cancellationToken)
    {
        if (request == null || string.IsNullOrEmpty(request.Club) && string.IsNullOrEmpty(request.Nom))
            throw new ArgumentException("You must specify NumeroClub or Nom");
        return next();
       // return next(request, cancellationToken);
        //throw new NotImplementedException();
    }
}
