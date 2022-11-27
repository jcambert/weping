using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Domain.Joueurs.Queries;

public class GetJoueurDetailSpidQuery : IGetJoueurDetailSpidQuery
{
    public string Licence { get; set; }
}
