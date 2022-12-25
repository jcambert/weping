using System;
using Volo.Abp.Domain.Entities;

namespace WePing.Girpe;

//[Queryable]
public class PartieSpid:Entity
{
    protected PartieSpid()
    {

    }

    internal PartieSpid(Guid joueur, string date, string nomPrenomAdv)
    => (JoueurId,Date,NomPrenomAdversaire) = (joueur,date,nomPrenomAdv);
    public virtual Guid JoueurId { get;protected set; }

    public virtual string Date { get; protected set; }


    public virtual string NomPrenomAdversaire { get; protected set; }


    public string ClassementAdversaire { get; set; }

    public string Epreuve { get; set; }


    public string VictoireOuDefaite { get; set; }


    public string Forfait { get; set; }
    public double PointsAcquisPerdus { get;  set; }

    public override object[] GetKeys()
        => new object[] { JoueurId, Date, NomPrenomAdversaire };
}   
