using Mediator;
using WePing.SmartPing.Domain.Organismes.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Organismes.Queries;

public interface IBrowseOrganismeQuery : ISpidRequestQuery, IRequest<BrowseOrganismeResponse>
{
    string Type { get; set; }

}


public sealed record BrowseOrganismeResponse(List<Organisme> Organismes);