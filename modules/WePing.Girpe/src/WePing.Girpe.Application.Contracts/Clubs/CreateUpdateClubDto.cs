using System.ComponentModel.DataAnnotations;

namespace WePing.Girpe.Clubs;

public class CreateUpdateClubDto
{
    #region info @see Smartping.ClubDto
    [Required]
    public string Identifiant { get; set; }

    [Required]
    public string Numero { get; set; }

    [Required]
    public string Nom { get; set; }

    public string Validation { get; set; }
    #endregion

    #region Detail @see SmartPing.ClubDetail

    public string NomSalle { get; set; } = string.Empty;

    public string AdresseSalle1 { get; set; } = string.Empty;

    public string AdresseSalle2 { get; set; } = string.Empty;

    public string AdresseSalle3 { get; set; } = string.Empty;

    public string CodePostalSalle { get; set; } = string.Empty;

    public string VilleSalle { get; set; } = string.Empty;

    public string Web { get; set; } = string.Empty;

    public string NomCorrespondant { get; set; } = string.Empty;

    public string PrenomCorrespondant { get; set; } = string.Empty;

    public string MailCorrespondant { get; set; } = string.Empty;

    public string TelephoneCorrespondant { get; set; } = string.Empty;

    public string Latitude { get; set; } = string.Empty;

    public string Longitude { get; set; } = string.Empty;

    #endregion

    public virtual string ConcurrencyStamp { get; set; }
}
