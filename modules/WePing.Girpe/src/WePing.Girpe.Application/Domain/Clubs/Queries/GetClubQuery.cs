using WePing.Girpe.Clubs.Queries;

namespace WePing.Girpe.Domain.Clubs.Queries;

public class GetClubQuery : IGetClubQuery
{
    public string Numero { get; set; }
}
