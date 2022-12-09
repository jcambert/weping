using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class BrowseJoueurClassementHandler : BaseRequestHandler<BrowseJoueurClassementQuery, BrowseJoueurClassementResponse, ListeJoueursClassement>
{

    public BrowseJoueurClassementHandler(ISpidRequestAppService requestService, IDeserializeService<ListeJoueursClassement> deserializer) : base(requestService, deserializer) { }

    public override async Task<BrowseJoueurClassementResponse> Handle(BrowseJoueurClassementQuery request, CancellationToken cancellationToken)
    {
       
        var result_as_stream = await RequestService.GetStreamAsync(request, "joueur_liste_cla", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new BrowseJoueurClassementResponse(data?.Joueurs ?? new());
    }
}
