using System;
using System.Collections.Generic;
using WePing.Girpe.Joueurs.Dto;

namespace WePing.Girpe.Joueurs.Queries;

public interface IBrowseJoueurQuery : IGirpeQuery<BrowseJoueurResponse>
{
    Guid ClubId { get; set; }

    string ClubNumero { get; set; }
}

public sealed record BrowseJoueurResponse(List<JoueurDto> Joueurs):GirpeResponse;
