using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.Girpe.Parties.Dto;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBrowseJoueurClassementQuery))]
public class JoueurPartiesSpidDto : EntityDto<Guid>
{

    Guid JoueurId { get; set; }

    public string Date { get; set; }


    public string NomPrenomAdversaire { get; set; }


    public string ClassementAdversaire { get; set; }

    public string Epreuve { get; set; }


    public string VictoireOuDefaite { get; set; }


    public string Forfait { get; set; }
}