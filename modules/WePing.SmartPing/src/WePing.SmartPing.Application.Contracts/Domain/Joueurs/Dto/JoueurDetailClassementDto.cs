using System.Diagnostics;

namespace WePing.SmartPing.Domain.Joueurs.Dto;

[DebuggerDisplay("{Licence}:{Nom} {Prenom}")]
public class JoueurDetailClassementDto
{
    public string Licence { get; set; }

    public string Nom { get; set; }

    public string Prenom { get; set; }

    public string NumeroClub { get; set; }

    public string NomClub { get; set; }


    public string Nationnalite { get; set; }


    public string ClassementGlobal { get; set; }

    public string PointsMensuels { get; set; }

    public string AncienClassementGlobal { get; set; }

    public string AnciensPoints { get; set; }

    public string Classement { get; set; }

    public string Categorie { get; set; }

    public string RangRegional { get; set; }
    public string RangDepartmental { get; set; }
    public string PointsOfficiels { get; set; }
    public string PropositionClassement { get; set; }
    public string PointsDebutSaison { get; set; }
}
