using WePing.Girpe.Clubs.Dto;

namespace WePing.Girpe.Clubs.Queries;

public interface IGetClubQuery : IGirpeQuery<GetClubResponse>
{
    string Numero { get; set; }
}

public sealed record GetClubResponse(ClubDto Club):GirpeResponse;