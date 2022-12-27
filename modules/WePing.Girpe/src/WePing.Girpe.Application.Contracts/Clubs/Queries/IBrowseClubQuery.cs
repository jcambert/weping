using System.Collections.Generic;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Domain;

namespace WePing.Girpe.Clubs.Queries;

public interface IBrowseClubQuery : IGirpeQuery<BrowseClubResponse>
{
    string Dep { get; set; }

    string Code { get; set; }

    string Ville { get; set; }

    string Numero { get; set; }
}

public sealed record BrowseClubResponse(List<Club> Clubs): GirpeResponse;
public sealed record BrowseClubResponseDto(List<ClubDto> Clubs);