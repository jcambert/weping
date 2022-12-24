
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.ObjectMapping;

namespace WePing.PointCalculator;
[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IBaremeProvider))]
public class BaremesProvider : DomainService, IBaremeProvider
{
    IRepository<Bareme, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Bareme, Guid>>();
    protected Type ObjectMapperContext { get; set; }
    protected IObjectMapper ObjectMapper => LazyServiceProvider.LazyGetService<IObjectMapper>(provider =>
        ObjectMapperContext == null
            ? provider.GetRequiredService<IObjectMapper>()
            : (IObjectMapper)provider.GetRequiredService(typeof(IObjectMapper<>).MakeGenericType(ObjectMapperContext)));
    public BaremesProvider()
    {

    }
    public async Task<List<BaremeDto>> LoadAsync()
    {

        var b = await Repository.GetListAsync();

        return ObjectMapper.Map<List<Bareme>, List<BaremeDto>>(b);
    }
}

internal interface IBaremeProvider
{
    Task<List<BaremeDto>> LoadAsync();
}