using Mediator;
using WePing.SmartPing.Domain.Clubs.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Clubs.Queries;

public interface IGetClubQuery : ISpidRequestQuery, IRequest<GetClubResponse>
{
    public string Numero { get; set; }
}

public sealed record GetClubResponse(Club club);