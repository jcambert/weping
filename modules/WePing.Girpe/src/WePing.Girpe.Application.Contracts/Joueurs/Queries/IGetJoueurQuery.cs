using WePing.Girpe.Joueurs.Dto;

namespace WePing.Girpe.Joueurs.Queries;

public interface IGetJoueurQuery : IGirpeQuery<GetJoueurResponse>
{
    string Licence { get; set; }

    bool ForceLoadClubIfNotSet { get; set; }

    UpdateJoueurFromSpidOption DetailOptions { get; set; }
}

public sealed record GetJoueurResponse(JoueurDto Joueur): GirpeResponse;
