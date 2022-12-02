using System;
using WePing.Girpe.Clubs.Queries;

namespace WePing.Girpe.Domain.Clubs.Queries;

public class BrowseClubQuery : IBrowseClubQuery
{
    public string Dep { get; set; }

    public string Code { get; set; }

    public string Ville { get; set; }

    public string Numero { get; set; }
    public int Number { get; set; }
}
