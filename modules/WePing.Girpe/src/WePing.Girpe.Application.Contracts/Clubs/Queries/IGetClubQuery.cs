using System;
using WePing.Girpe.Clubs.Dto;

namespace WePing.Girpe.Clubs.Queries;

public interface IGetClubQuery : IGirpeQuery<GetClubResponse>
{
    string Numero { get; set; }

    Guid Id { get; set; }
}

public sealed record GetClubResponse(ClubDto Club):GirpeResponse;