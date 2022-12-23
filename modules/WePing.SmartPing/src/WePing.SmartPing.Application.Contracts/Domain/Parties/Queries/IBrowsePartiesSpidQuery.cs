using WePing.SmartPing.Domain.Parties.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Parties.Queries;

public interface IBrowsePartiesSpidQuery : ISpidRequestQuery<BrowsePartiesSpidResponse>
{
    string NumLic { get; set; }
}


public sealed record BrowsePartiesSpidResponse(List<PartiesSpid> Parties) : Response;