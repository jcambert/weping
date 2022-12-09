using WePing.SmartPing.Domain.ClubDetails.Domain;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using WePing.SmartPing.Spid.Domain.ClubDetails.Queries;

namespace WePing.SmartPing.Spid.Handlers.ClubDetails;

public class GetClubDetailsHandler : BaseRequestHandler<GetClubDetailQuery, GetClubDetailResponse, ListeClubdetails>
{
    public GetClubDetailsHandler(ISpidRequestAppService requestService, IDeserializeService<ListeClubdetails> deserializer) : base(requestService, deserializer)
    {
    }

    public override async Task<GetClubDetailResponse> Handle(GetClubDetailQuery request, CancellationToken cancellationToken)
    {
        var result_as_stream = await RequestService.GetStreamAsync(request, "club_detail", cancellationToken);
        var data = Deserializer.To(result_as_stream);
        return new GetClubDetailResponse(data?.Club ?? new());
    }
}
