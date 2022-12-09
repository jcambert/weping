using WePing.SmartPing.Domain.Epreuves.Domain;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Spid.Domain.Epreuves.Queries;

namespace WePing.SmartPing.Spid.Handlers.Epreuves;

public class BrowseEpreuveHandler : BaseRequestHandler<BrowseEpreuveQuery, BrowseEpreuveResponse, ListeEpreuve>
{
    public BrowseEpreuveHandler(ISpidRequestAppService requestService, IDeserializeService<ListeEpreuve> deserializer) : base(requestService, deserializer)
    {
    }

    public override async Task<BrowseEpreuveResponse> Handle(BrowseEpreuveQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream = await RequestService.GetStreamAsync(request, "epreuves", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new BrowseEpreuveResponse(data?.Epreuves ?? new());
    }
}
