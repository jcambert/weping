using System.ComponentModel;

namespace WePing.SmartPing.Domain.Clubs.Queries;

public class BrowseClubsQuery:IBrowseClubsQuery
{
    [Default]
    [Description("Département")]
    public string Dep { get; set; }

    public string Code { get; set; }

    public string Ville { get; set; }

    public string Numero { get; set; }

}
