using WePing.Girpe.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace WePing.Girpe;

public abstract class GirpeAppService : ApplicationService
{
    protected IMediator Mediator =>LazyServiceProvider.LazyGetRequiredService<IMediator>();
    
    protected GirpeAppService()
    {
        LocalizationResource = typeof(GirpeResource);
        ObjectMapperContext = typeof(GirpeApplicationModule);
    }
}
