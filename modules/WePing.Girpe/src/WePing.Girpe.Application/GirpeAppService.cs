using WePing.Girpe.Localization;
using Volo.Abp.Application.Services;
using Mediator;

namespace WePing.Girpe;

public abstract class GirpeAppService : ApplicationService
{
    protected IMediator Mediator { get; init; }
    protected GirpeAppService(IMediator mediator)
    {
        LocalizationResource = typeof(GirpeResource);
        ObjectMapperContext = typeof(GirpeApplicationModule);
        Mediator = mediator;
    }
}
