using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Joueurs.Queries;

public interface IBrowseJoueurDetailSpidClaQuery : ISpidRequestQuery<BrowseJoueurDetailSpidClaResponse>
{
    /// <summary>
    /// In this case must be Numero du club
    /// </summary>
    string Club { get; set; }
}

public sealed record BrowseJoueurDetailSpidClaResponse(List<JoueurDetailSpidCla> Joueurs):Response;