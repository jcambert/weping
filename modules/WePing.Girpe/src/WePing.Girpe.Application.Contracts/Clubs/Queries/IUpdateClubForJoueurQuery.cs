using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Domain;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Dto;

namespace WePing.Girpe.Clubs.Queries;

public interface IUpdateClubForJoueurQuery:IGirpeQuery<UpdateClubForJoueurResponse>
{
    string Licence { get; set; }
}

public sealed record UpdateClubForJoueurResponse(Club Club,Joueur Joueur) : GirpeResponse;
public sealed record UpdateClubForJoueurResponseDto(ClubDto Club, JoueurDto Joueur);