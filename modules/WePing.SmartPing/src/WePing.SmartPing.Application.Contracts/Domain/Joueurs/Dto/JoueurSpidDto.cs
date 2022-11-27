using System.Diagnostics;

namespace WePing.SmartPing.Domain.Joueurs.Dto;


[DebuggerDisplay("{Licence}:{Nom} {Prenom}")]
public class JoueurSpidDto
{
    public string Licence { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string NumeroClub { get; set; }
    public string NomClub { get; set; }
}
