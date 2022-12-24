using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace WePing.PointCalculator;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBaremeAppService))]
public class BaremeAppService : CrudAppService<Bareme, BaremeDto, Guid>, IBaremeAppService
{
    //protected IRepository<Bareme,Guid> baremeRepository=>LazyServiceProvider.LazyGetRequiredService<IRepository<Bareme,Guid>>();
    public BaremeAppService(IRepository<Bareme, Guid> baremeRepository) : base(baremeRepository)
    {
    }

}
