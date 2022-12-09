using System.Linq;
using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class GetJoueurDetailSpidClaHandler : BaseRequestHandler<GetJoueurDetailSpidClaQuery, GetJoueurDetailSpidClaResponse, ListeJoueursDetailSpidCla>
{
    public GetJoueurDetailSpidClaHandler(ISpidRequestAppService requestService, IDeserializeService<ListeJoueursDetailSpidCla> deserializer) : base(requestService, deserializer)
    {
    }

    public override async Task<GetJoueurDetailSpidClaResponse> Handle(GetJoueurDetailSpidClaQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream = await RequestService.GetStreamAsync(request, "joueur_licence_spid", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new GetJoueurDetailSpidClaResponse(data?.Joueurs.FirstOrDefault() ?? new());
    }
}
