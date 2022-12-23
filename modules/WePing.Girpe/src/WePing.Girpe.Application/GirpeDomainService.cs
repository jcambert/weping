using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Domain.Services;
using Volo.Abp.ObjectMapping;
using WePing.SmartPing.Spid;

namespace WePing.Girpe;

public class GirpeDomainService:DomainService
{
    protected Type ObjectMapperContext { get; set; }
    protected IObjectMapper ObjectMapper => LazyServiceProvider.LazyGetService<IObjectMapper>(provider =>
        ObjectMapperContext == null
            ? provider.GetRequiredService<IObjectMapper>()
            : (IObjectMapper)provider.GetRequiredService(typeof(IObjectMapper<>).MakeGenericType(ObjectMapperContext)));

    protected ISpidAppService Spid => GetRequiredService<ISpidAppService>();

    protected IMediator Mediator => GetRequiredService<IMediator>();

    protected T GetRequiredService<T>() => LazyServiceProvider.LazyGetRequiredService<T>();
}
