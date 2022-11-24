using WePing.SmartPing.Domain.Epreuves.Queries;

namespace WePing.SmartPing.Spid.Domain.Epreuves.Queries;

public class BrowseEpreuveQuery : IBrowseEpreuveQuery
{
    public string Organisme { get; set; }
    public string Type { get; set; }
}
