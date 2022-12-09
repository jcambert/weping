using WePing.Girpe.Joueurs.Queries;

namespace WePing.Girpe.Joueurs;

public class GetJoueurQuery : IGetJoueurQuery
{
    public string Licence { get; set; }
}
