
using WePing.SmartPing.Domain.ClubDetails.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.ClubDetails.Queries;

public interface IGetClubDetailQuery : ISpidRequestQuery<GetClubDetailResponse>
{
    string Club { get; set; }
}

public sealed record GetClubDetailResponse(ClubDetail Club):Response;
