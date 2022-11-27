using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Domain.Joueurs.Queries;

public class GetJoueurDetailSpidClaQuery : IGetJoueurDetailSpidClaQuery
{
    ///<inheritdoc/>
    public string Licence { get; set; }
}
