using WePing.Girpe.Localization;
using Volo.Abp.Application.Services;

namespace WePing.Girpe;

public abstract class GirpeAppService : ApplicationService
{
    protected GirpeAppService()
    {
        LocalizationResource = typeof(GirpeResource);
        ObjectMapperContext = typeof(GirpeApplicationModule);
    }
}
