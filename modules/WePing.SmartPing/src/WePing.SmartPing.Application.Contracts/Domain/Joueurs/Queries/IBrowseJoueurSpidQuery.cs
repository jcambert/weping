using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Joueurs.Queries;

public interface IBrowseJoueurSpidQuery : ISpidRequestQuery<BrowseJoueurSpidResponse>
{
    string Club { get; set; }

    string Licence { get; set; }
    string Nom { get; set; }

    string Prenom { get; set; }

    string Valid { get; set; } 
}

public sealed record BrowseJoueurSpidResponse(List<JoueurSpid> Joueurs):Response;