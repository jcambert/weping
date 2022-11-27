using Mediator;
using WePing.Girpe.Joueurs.Dto;

namespace WePing.Girpe.Joueurs.Queries;

public interface IGetJoueurQuery : IGirpeQuery, IRequest<GetJoueurResponse>
{
    string Licence { get; set; }
}

public sealed record GetJoueurResponse(JoueurDto Joueur): GirpeResponse;
