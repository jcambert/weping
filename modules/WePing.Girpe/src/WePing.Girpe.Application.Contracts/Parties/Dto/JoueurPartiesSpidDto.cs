using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.Girpe.Parties.Dto;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBrowseJoueurClassementQuery))]
public class JoueurPartiesSpidDto : EntityDto<Guid>
{
}
