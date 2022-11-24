using System.Diagnostics;

namespace WePing.SmartPing.Domain.Divisions.Dto;

[DebuggerDisplay("{Id}-{Libelle}")]
public class DivisionDto
{
    #region public properties

    public string Id { get; set; }

    public string Libelle { get; set; }

    #endregion
}
