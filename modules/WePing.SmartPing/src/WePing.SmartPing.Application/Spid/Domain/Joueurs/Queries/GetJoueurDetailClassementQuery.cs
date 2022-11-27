using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Domain.Joueurs.Queries;

public class GetJoueurDetailClassementQuery : IGetJoueurDetailClassementQuery
{
    public string Licence { get; set; }
}
