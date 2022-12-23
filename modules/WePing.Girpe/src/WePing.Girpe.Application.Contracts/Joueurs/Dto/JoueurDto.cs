using System;
using Volo.Abp.Application.Dtos;

namespace WePing.Girpe.Joueurs.Dto;

public class JoueurDto : EntityDto<Guid>
{
    public Guid ClubId { get; set; }
    public string Licence { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }

    public string Classement { get; set; }

    public string LicenceId { get; set; }


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


    public string PointsMensuel { get; set; }


    public string AncienPointsMensuel { get; set; }

    public string PointsInitials { get; set; }


    public string Mutation { get; set; }

    public string Nationnalite { get; set; }

    public string Arbitre { get; set; }

    public string JugeArbitre { get; set; }

    public string Tech { get; set; }

    


    public string ClassementGlobal { get; set; }

    public string PointsMensuels { get; set; }

    public string AncienClassementGlobal { get; set; }

    public string AnciensPoints { get; set; }


    public string Categorie { get; set; }

    public string RangRegional { get; set; }
    public string RangDepartmental { get; set; }
    public string PointsOfficiels { get; set; }
    public string PropositionClassement { get; set; }
    public string PointsDebutSaison { get; set; }
}
