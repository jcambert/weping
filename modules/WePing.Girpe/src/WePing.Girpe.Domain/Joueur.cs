using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;
using WeUtilities;

namespace WePing.Girpe.Joueurs;

[Queryable]
public class Joueur : AuditedAggregateRoot<Guid> //Entity<Guid>
{
    protected Joueur()
    {

    }
    public Joueur(Guid id,string licence,string nom,string prenom)
    {
        Id = id;
        Licence=licence;
        Nom=nom;
        Prenom=prenom;
        PartiesSpid = new ();
    }

    public Guid ClubId { get; set; }
    
    public string Licence { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public virtual string NumeroClub { get; set; }
    public virtual string NomClub { get; set; }
    public string Classement { get; set; }

    #region @see SmartPing.JoueurDetailSpidCla
    public string LicenceId { get; set; }

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
    #endregion

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

    public virtual List<PartieSpid> PartiesSpid{get;protected set;}

    public void AddPartieSpid(string date,string nomPrenomAdv,string classementAdversaire,string epreuve,string victoireOuDefaite,string forfait,double points)
    {
        var partie=PartiesSpid.FirstOrDefault(x => x.JoueurId == Id && x.Date == date && x.NomPrenomAdversaire == nomPrenomAdv);
        if (partie == null)
        {
            PartiesSpid.Add(new(Id,date,nomPrenomAdv));
        }
        partie.ClassementAdversaire = classementAdversaire;
        partie.Epreuve = epreuve;
        partie.VictoireOuDefaite = victoireOuDefaite;
        partie.Forfait = forfait;
        partie.PointsAcquisPerdus = points;
    }
}
