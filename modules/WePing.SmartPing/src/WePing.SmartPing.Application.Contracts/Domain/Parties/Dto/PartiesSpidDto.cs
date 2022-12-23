using System.Diagnostics;

namespace WePing.SmartPing.Domain.Parties.Dto;

[DebuggerDisplay("{NomPrenomAdversaire}:{ClassementAdversaire}->{VictoireOuDefaite}")]
public class PartiesSpidDto
{
    public string Date { get; set; }

    
    public string NomPrenomAdversaire { get; set; }

    
    public string ClassementAdversaire { get; set; }

    public string Epreuve { get; set; }

   
    public string VictoireOuDefaite { get; set; }

   
    public string Forfait { get; set; }
}
