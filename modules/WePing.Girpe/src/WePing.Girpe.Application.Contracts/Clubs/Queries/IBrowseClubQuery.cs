using Mediator;
using System.Collections.Generic;
using WePing.Girpe.Clubs.Dto;

namespace WePing.Girpe.Clubs.Queries;

public interface IBrowseClubQuery : IGirpeQuery, IRequest<BrowseClubResponse>
{
}

public sealed record BrowseClubResponse(List<ClubDto> Clubs): GirpeResponse;