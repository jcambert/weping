using WePing.SmartPing.Domain.Divisions.Domain;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Spid.Domain.Divisions.Queries;

namespace WePing.SmartPing.Spid.Handlers.Divisions;

public class BrowsDivisionHandler : BaseRequestHandler<BrowseDivisionQuery, BrowseDivisionResponse, ListeDivisions>
{
    public BrowsDivisionHandler(ISpidRequestAppService requestService, IDeserializeService<ListeDivisions> deserializer) : base(requestService, deserializer)
    {
    }

    public async override Task<BrowseDivisionResponse> Handle(BrowseDivisionQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream = await RequestService.GetStreamAsync(request, "division", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new BrowseDivisionResponse(data?.Divisions ?? new());
    }
}
