using WePing.SmartPing.Domain.Clubs.Domain;
using WePing.SmartPing.Domain.Clubs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Clubs;

public class BrowseClubsHandler : BaseRequestHandler<BrowseClubsQuery, BrowseClubResponse, ListeClubs>
{

    public BrowseClubsHandler(ISpidRequestAppService requestService, IDeserializeService<ListeClubs> deserializer) : base(requestService, deserializer) { }
    
    public override async Task<BrowseClubResponse> Handle(BrowseClubsQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream=await RequestService.GetStreamAsync(request, "club_liste",cancellationToken);
        var data=Deserializer.To(result_as_stream);
        return new BrowseClubResponse(data?.Clubs ?? new());
    }
}
