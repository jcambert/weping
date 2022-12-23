using WePing.Girpe.Parties.Dto;

namespace WePing.Girpe.Parties.Queries;

internal interface IBrowseJoueurPartiesSpidQuery : IGirpeQuery<BrowseJoueurPartiesSpidResponse>
{
    string Licence { get; set; }
}

public sealed record BrowseJoueurPartiesSpidResponse(JoueurPartiesSpidDto Parties) :GirpeResponse;