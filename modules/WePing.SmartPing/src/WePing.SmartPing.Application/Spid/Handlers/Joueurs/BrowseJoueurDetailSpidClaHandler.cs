using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class BrowseJoueurDetailSpidClaHandler : BaseRequestHandler<BrowseJoueurDetailSpidClaQuery, BrowseJoueurDetailSpidClaResponse, ListeJoueursDetailSpidCla>
{
    public const string API_ENDPOINT = "joueur_licence_spid";
    public BrowseJoueurDetailSpidClaHandler(ISpidRequestAppService requestService, IDeserializeService<ListeJoueursDetailSpidCla> deserializer) : base(requestService, deserializer)
    {
    }

    public override async Task<BrowseJoueurDetailSpidClaResponse> Handle(BrowseJoueurDetailSpidClaQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream = await RequestService.GetStreamAsync(request, API_ENDPOINT, cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new BrowseJoueurDetailSpidClaResponse(data?.Joueurs ?? new());
    }
}
