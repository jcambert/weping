using System.Diagnostics;

namespace WePing.SmartPing.Domain.Organismes.Dto;

[DebuggerDisplay("{Id}-{Code}-{Libelle}")]
public class OrganismeDto
{


    #region public properties

    public string Id { get; set; }

    public string Libelle { get; set; }

    public string Code { get; set; }

    #endregion


}
