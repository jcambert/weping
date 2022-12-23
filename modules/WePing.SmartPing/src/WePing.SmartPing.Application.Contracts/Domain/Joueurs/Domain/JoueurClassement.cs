using System.Xml.Serialization;

namespace WePing.SmartPing.Domain.Joueurs.Domain;

[XmlType(AnonymousType = true)]
[XmlRoot(ElementName = "liste")]
public class ListeJoueursClassement
{
    [XmlElement(ElementName = "joueur")]
    public List<JoueurClassement> Joueurs { get; set; } = new List<JoueurClassement>();
}
public class JoueurClassement
{

    #region public properties

    [XmlElement(ElementName = "licence")]
    public string Licence { get; set; }


    [XmlElement(ElementName = "nom")]
    public string Nom { get; set; }


    [XmlElement(ElementName = "prenom")]
    public string Prenom { get; set; }


    [XmlElement(ElementName = "nclub")]
    public string NumeroClub { get; set; }

    [XmlElement(ElementName = "club")]
    public string NomClub { get; set; }

    [XmlElement(ElementName = "clast")]
    public string Classement { get; set; }
    
    #endregion

    
}

