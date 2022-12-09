using System.Linq;
using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class GetJoueurDetailSpidHandler : BaseRequestHandler<GetJoueurDetailSpidQuery, GetJoueurDetailSpidResponse, ListeJoueursDetailSpid>
{
    public GetJoueurDetailSpidHandler(ISpidRequestAppService requestService, IDeserializeService<ListeJoueursDetailSpid> deserializer) : base(requestService, deserializer)
    {
    }

    public override async Task<GetJoueurDetailSpidResponse> Handle(GetJoueurDetailSpidQuery request, CancellationToken cancellationToken)
    {
        var url = await RequestService.GetQueryAsync(request, "joueur_licence_spid");
        var result_as_stream = await RequestService.GetStreamAsync(request, "joueur_licence_spid", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new GetJoueurDetailSpidResponse(data.Joueurs.FirstOrDefault() ?? new());
    }
}
