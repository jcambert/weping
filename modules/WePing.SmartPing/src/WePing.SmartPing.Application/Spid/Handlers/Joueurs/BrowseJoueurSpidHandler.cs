using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class BrowseJoueurSpidHandler : BaseRequestHandler<BrowseJoueurSpidQuery, BrowseJoueurSpidResponse, ListeJoueursSpid>
{
    public BrowseJoueurSpidHandler(ISpidRequestAppService requestService, IDeserializeService<ListeJoueursSpid> deserializer) : base(requestService, deserializer)
    {
    }

    public override async Task<BrowseJoueurSpidResponse> Handle(BrowseJoueurSpidQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream = await RequestService.GetStreamAsync(request, "joueur_liste_spid", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new BrowseJoueurSpidResponse(data?.Joueurs ?? new());
    }
}
