using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Domain;

namespace WePing.Girpe.Clubs.Queries;

public interface IGetClubQuery : IGirpeQuery<GetClubResponse>
{
    string Numero { get; set; }

    Guid Id { get; set; }
}

public sealed record GetClubResponse(Club Club):GirpeResponse;

public sealed record GetClubResponseDto(ClubDto Club);