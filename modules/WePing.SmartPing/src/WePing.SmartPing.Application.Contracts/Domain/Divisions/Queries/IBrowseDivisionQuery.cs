using Mediator;
using WePing.SmartPing.Domain.Divisions.Domain;
using WePing.SmartPing.Domain.Epreuves.Domain;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Divisions.Queries;

public interface IBrowseDivisionQuery : ISpidRequestQuery<BrowseDivisionResponse>
{
    public string Organisme { get; set; }

    public string Epreuve { get; set; }

    public string Type { get; set; }
}

public sealed record BrowseDivisionResponse(List<Division> Divisions):Response;
