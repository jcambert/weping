using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Joueurs.Dto;

namespace WePing.Girpe.Clubs.Queries;

public interface IUpdateClubForJoueurQuery:IGirpeQuery<UpdateClubForJoueurResponse>
{
    string Licence { get; set; }
}

public sealed record UpdateClubForJoueurResponse(ClubDto Club,JoueurDto Joueur) : GirpeResponse;