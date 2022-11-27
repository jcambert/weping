using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Domain.Joueurs.Queries;

public class BrowseJoueurDetailSpidClaQuery: IBrowseJoueurDetailSpidClaQuery
{
    ///<inheritdoc/>
    public string Club { get; set; }
}
