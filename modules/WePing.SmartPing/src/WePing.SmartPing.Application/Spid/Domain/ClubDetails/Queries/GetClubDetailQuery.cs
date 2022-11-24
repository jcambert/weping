using WePing.SmartPing.Domain.ClubDetails.Queries;

namespace WePing.SmartPing.Spid.Domain.ClubDetails.Queries;

public class GetClubDetailQuery:IGetClubDetailQuery
{
    public string Club { get; set; }
}
