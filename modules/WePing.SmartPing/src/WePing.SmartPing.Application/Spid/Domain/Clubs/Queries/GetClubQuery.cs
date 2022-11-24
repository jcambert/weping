using WePing.SmartPing.Domain.Clubs.Queries;

namespace WePing.SmartPing.Spid.Domain.Clubs.Queries;

public class GetClubQuery : IGetClubQuery
{
    public string Numero { get; set; }
}
