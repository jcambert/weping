using WePing.SmartPing.Domain.Organismes.Domain;
using WePing.SmartPing.Domain.Organismes.Queries;
using WePing.SmartPing.Spid.Domain.Organismes.Queries;

namespace WePing.SmartPing.Spid.Handlers.Organismes;

public class BrowseOrganismeHandler : BaseRequestHandler<BrowseOrganismeQuery, BrowseOrganismeResponse, ListeOrganismes>
{
    public BrowseOrganismeHandler(ISpidRequestAppService requestService, IDeserializeService<ListeOrganismes> deserializer) : base(requestService, deserializer)
    {
    }

    public override async Task<BrowseOrganismeResponse> Handle(BrowseOrganismeQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream = await RequestService.GetStreamAsync(request, "organismes", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new BrowseOrganismeResponse(data?.Organismes ?? new());
    }
}
