using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Joueurs.Queries;

public interface IBrowseJoueurClassementQuery : ISpidRequestQuery<BrowseJoueurClassementResponse>
{
    string Club { get; set; }

    string Nom { get; set; }

    string Prenom { get; set; }
}

public sealed record BrowseJoueurClassementResponse(List<JoueurClassement> Joueurs):Response;