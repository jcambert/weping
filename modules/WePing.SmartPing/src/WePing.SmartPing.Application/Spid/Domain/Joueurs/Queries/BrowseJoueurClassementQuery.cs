using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Domain.Joueurs.Queries;

public class BrowseJoueurClassementQuery : IBrowseJoueurClassementQuery
{
    public string Club { get; set ; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
}
