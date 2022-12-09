using System.Linq;
using WePing.SmartPing.Domain.Clubs.Domain;
using WePing.SmartPing.Domain.Clubs.Queries;
using WePing.SmartPing.Spid.Domain.Clubs.Queries;

namespace WePing.SmartPing.Spid.Handlers.Clubs;

public class GetClubHandler : BaseRequestHandler<GetClubQuery, GetClubResponse, ListeClubs>
{
    public GetClubHandler(ISpidRequestAppService requestService, IDeserializeService<ListeClubs> deserializer) : base(requestService, deserializer)
    {
    }

    public override async Task<GetClubResponse> Handle(GetClubQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream = await RequestService.GetStreamAsync(request, "club_liste", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new GetClubResponse(data?.Clubs.FirstOrDefault() ?? new());
    }
}
