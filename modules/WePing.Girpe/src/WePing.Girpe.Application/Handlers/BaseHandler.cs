using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Linq;
using Volo.Abp.ObjectMapping;
using WePing.SmartPing.Spid;

namespace WePing.Girpe.Handlers;

public abstract class BaseHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IRequest<TResponse>
{
    protected BaseHandler(IAbpLazyServiceProvider serviceProvider)
    {
        LazyServiceProvider = serviceProvider;
    }
    protected IAbpLazyServiceProvider LazyServiceProvider { get; init; }
    protected IAsyncQueryableExecuter AsyncExecuter => LazyServiceProvider.LazyGetRequiredService<IAsyncQueryableExecuter>();

    protected Type ObjectMapperContext { get; set; }
    protected IObjectMapper ObjectMapper => LazyServiceProvider.LazyGetService<IObjectMapper>(provider =>
        ObjectMapperContext == null
            ? provider.GetRequiredService<IObjectMapper>()
            : (IObjectMapper)provider.GetRequiredService(typeof(IObjectMapper<>).MakeGenericType(ObjectMapperContext)));

    protected ISpidAppService Spid => LazyServiceProvider.LazyGetRequiredService<ISpidAppService>();
    protected IMediator Mediator => LazyServiceProvider.LazyGetRequiredService<IMediator>();

    public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
}
