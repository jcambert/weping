using System.Xml.Serialization;

namespace WePing.SmartPing.Domain.Parties.Domain;

[XmlType(AnonymousType = true)]
[XmlRoot(ElementName = "liste")]
public class ListePartiesSpid
{
    [XmlElement(ElementName = "partie")]
    public List<PartiesSpid> Parties { get; set; } = new List<PartiesSpid>();
}
public class PartiesSpid
{
    #region public properties

    [XmlElement(ElementName = "date")]
    public string Date { get; set; }

    [XmlElement(ElementName = "nom")]
    public string NomPrenomAdversaire { get; set; }

    [XmlElement(ElementName = "classement")]
    public string ClassementAdversaire { get; set; }

    [XmlElement(ElementName = "epreuve")]
    public string Epreuve { get; set; }

    [XmlElement(ElementName = "victoire")]
    public string VictoireOuDefaite { get; set; }

    [XmlElement(ElementName = "forfait")]
    public string Forfait { get; set; }
    #endregion
}
