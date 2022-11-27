using System.Xml.Serialization;

namespace WePing.SmartPing.Domain.Joueurs.Domain;




[XmlType(AnonymousType = true)]
[XmlRoot(ElementName = "liste")]
public class ListeJoueursSpid
{
    [XmlElement(ElementName = "joueur")]
    public List<JoueurSpid> Joueurs { get; set; } = new List<JoueurSpid>();
}
public class JoueurSpid
{

    #region public properties

    [XmlElement(ElementName = "licence")]
    public string Licence { get; set; }


    [XmlElement(ElementName = "nom")]
    public string Nom { get; set; }


    [XmlElement(ElementName = "prenom")]
    public string Prenom { get; set; }


    [XmlElement(ElementName = "club")]
    public string NumeroClub { get; set; }

    [XmlElement(ElementName = "nclub")]
    public string NomClub { get; set; }



    #endregion


}
