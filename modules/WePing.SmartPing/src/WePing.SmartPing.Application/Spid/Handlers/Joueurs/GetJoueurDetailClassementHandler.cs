using System.Linq;
using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Joueurs;

public class GetJoueurDetailClassementHandler : BaseRequestHandler<GetJoueurDetailClassementQuery, GetJoueurDetailClassementResponse, ListeJoueursDetailClassement>
{

    public GetJoueurDetailClassementHandler(ISpidRequestAppService requestService, IDeserializeService<ListeJoueursDetailClassement> deserializer) : base(requestService, deserializer) { }

    public override async Task<GetJoueurDetailClassementResponse> Handle(GetJoueurDetailClassementQuery request, CancellationToken cancellationToken)
    {
       
        var result_as_stream = await RequestService.GetStreamAsync(request, "joueur_detail_cla", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new GetJoueurDetailClassementResponse(data.Joueurs.FirstOrDefault() ?? new());
    }
}
