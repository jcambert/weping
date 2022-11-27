using System.Diagnostics;

namespace WePing.SmartPing.Domain.Joueurs.Dto;

[DebuggerDisplay("{Licence}:{Nom} {Prenom}")]
public class JoueurDetailSpidDto
{
    public string LicenceId { get; set; }

    public string Licence { get; set; }


    public string Nom { get; set; }



    public string Prenom { get; set; }


    public string NumeroClub { get; set; }

    public string NomClub { get; set; }

    public string Sexe { get; set; }

    public string Type { get; set; }
    public string CertificatMedical { get; set; }
    public string DateDeValidationDuCertificatMedical { get; set; }
    public string Echelon { get; set; }

    public string Place { get; set; }

    public string CategorieAge { get; set; }

    public string PointClassement { get; set; }
}
