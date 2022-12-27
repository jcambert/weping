using System.Collections.Generic;
using WePing.Girpe.Joueurs.Dto;

namespace WePing.Girpe.Joueurs.Queries;

public interface IBrowseJoueurQuery : IGirpeQuery<BrowseJoueurResponse>
{
    Guid ClubId { get; set; }

    string ClubNumero { get; set; }

    bool ForceLoadClubIfNotSet { get; set; }
}

public sealed record BrowseJoueurResponse(List<Joueur> Joueurs):GirpeResponse;
public sealed record BrowseJoueurResponseDto(List<JoueurDto> Joueurs) ;
