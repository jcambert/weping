using WePing.SmartPing.Domain.Divisions.Queries;

namespace WePing.SmartPing.Spid.Domain.Divisions.Queries;

public class BrowseDivisionQuery : IBrowseDivisionQuery
{
    public string Organisme { get; set; }
    public string Epreuve { get; set; }
    public string Type { get; set; }
}
