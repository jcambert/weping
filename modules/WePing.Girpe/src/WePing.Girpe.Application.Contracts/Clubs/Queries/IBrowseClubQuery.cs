using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Domain;

namespace WePing.Girpe.Clubs.Queries;

public interface IBrowseClubQuery : IGirpeQuery<BrowseClubResponse>
{
    string Dep { get; set; }

    string Code { get; set; }

    string Ville { get; set; }

    string Numero { get; set; }
    int Number { get; set; }
}

public sealed record BrowseClubResponse(List<ClubDto> Clubs): GirpeResponse;