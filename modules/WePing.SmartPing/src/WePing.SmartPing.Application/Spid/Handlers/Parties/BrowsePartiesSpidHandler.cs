using WePing.SmartPing.Domain.Parties.Domain;
using WePing.SmartPing.Domain.Parties.Queries;
using WePing.SmartPing.Spid.Domain.Parties.Queries;

namespace WePing.SmartPing.Spid.Handlers.Parties;

public class BrowsePartiesSpidHandler : BaseRequestHandler<BrowsePartiesSpidQuery, BrowsePartiesSpidResponse, ListePartiesSpid>
{
    public BrowsePartiesSpidHandler(ISpidRequestAppService requestService, IDeserializeService<ListePartiesSpid> deserializer) : base(requestService, deserializer)
    {
    }

    public override async Task<BrowsePartiesSpidResponse> Handle(BrowsePartiesSpidQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream = await RequestService.GetStreamAsync(request, "joueur_partie_spid", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new BrowsePartiesSpidResponse(data?.Parties ?? new());
    }
}
