using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WePing.SmartPing.Domain.Joueurs.Domain;

[XmlType(AnonymousType = true)]
[XmlRoot(ElementName = "liste")]
public class ListeJoueursDetailClassement
{
    [XmlElement(ElementName = "joueur")]
    public List<JoueurDetailClassement> Joueurs { get; set; } = new List<JoueurDetailClassement>();
}
public class JoueurDetailClassement
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

    [XmlElement(ElementName = "natio")]
    public string Nationnalite { get; set; }

    [XmlElement(ElementName = "clglob")]
    public string ClassementGlobal { get; set; }
    [XmlElement(ElementName = "point")]
    public string PointsMensuels { get; set; }
    [XmlElement(ElementName = "aclglob")]
    public string AncienClassementGlobal { get; set; }
    [XmlElement(ElementName = "apoint")]
    public string AnciensPoints { get; set; }

    [XmlElement(ElementName = "clast")]
    public string Classement { get; set; }

    [XmlElement(ElementName = "categ")]
    public string Categorie { get; set; }

    [XmlElement(ElementName = "rangreg")]
    public string RangRegional { get; set; }
    [XmlElement(ElementName = "rangdep")]
    public string RangDepartmental { get; set; }
    [XmlElement(ElementName = "valcla")]
    public string PointsOfficiels { get; set; }
    [XmlElement(ElementName = "clpro")]
    public string PropositionClassement { get; set; }
    [XmlElement(ElementName = "valinit")]
    public string PointsDebutSaison { get; set; }
    #endregion


}

