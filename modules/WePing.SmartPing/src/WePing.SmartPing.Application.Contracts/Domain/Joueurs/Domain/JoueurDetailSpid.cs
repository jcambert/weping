using System.Xml.Serialization;

namespace WePing.SmartPing.Domain.Joueurs.Domain;

[XmlType(AnonymousType = true)]
[XmlRoot(ElementName = "liste")]
public class ListeJoueursDetailSpid
{
    [XmlElement(ElementName = "licence")]
    public List<JoueurDetailSpid> Joueurs { get; set; } = new List<JoueurDetailSpid>();
}
public class JoueurDetailSpid { 

    #region public properties

    [XmlElement(ElementName = "idlicence")]
    public string LicenceId { get; set; }


    [XmlElement(ElementName = "licence")]
    public string Licence { get; set; }

    [XmlElement(ElementName = "nom")]
    public string Nom { get; set; }


    [XmlElement(ElementName = "prenom")]
    public string Prenom { get; set; }


    [XmlElement(ElementName = "numclub")]
    public string NumeroClub { get; set; }

    [XmlElement(ElementName = "nomclub")]
    public string NomClub { get; set; }

    [XmlElement(ElementName = "sexe")]
    public string Sexe { get; set; }

    [XmlElement(ElementName = "type")]
    public string Type { get; set; }
    [XmlElement(ElementName = "certif")]
    public string CertificatMedical { get; set; }
    [XmlElement(ElementName = "validation")]
    public string DateDeValidationDuCertificatMedical { get; set; }
    [XmlElement(ElementName = "echelon")]
    public string Echelon { get; set; }

    [XmlElement(ElementName = "place")]
    public string Place { get; set; }

    [XmlElement(ElementName = "cat")]
    public string CategorieAge { get; set; }

    [XmlElement(ElementName = "point")]
    public string PointClassement { get; set; }
    #endregion


}

