using Mediator;
using WePing.Girpe.Clubs.Dto;

namespace WePing.Girpe.Clubs.Queries;

public interface IGetClubQuery : IGirpeQuery, IRequest<GetClubResponse>
{
    string Numero { get; set; }
}

public sealed record GetClubResponse(ClubDto Club):GirpeResponse;