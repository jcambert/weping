using WePing.SmartPing.Domain.Clubs.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Clubs.Queries;

public interface IBrowseClubsQuery : ISpidRequestQuery<BrowseClubResponse>
{
    string Dep { get; set; }

    string Code { get; set; }

    string Ville { get; set; }

    string Numero { get; set; }

}

public sealed record BrowseClubResponse(List<Club> clubs):Response;
