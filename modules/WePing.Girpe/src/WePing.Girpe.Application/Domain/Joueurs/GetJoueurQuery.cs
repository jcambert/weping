using WePing.Girpe.Joueurs.Queries;

namespace WePing.Girpe.Domain.Joueurs;

public class GetJoueurQuery : IGetJoueurQuery
{
    public string Licence { get; set; }
}
