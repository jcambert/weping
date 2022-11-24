using WePing.SmartPing.Localization;
using Volo.Abp.Application.Services;

namespace WePing.SmartPing;

public abstract class SmartPingAppService : ApplicationService
{
    protected SmartPingAppService()
    {
        LocalizationResource = typeof(SmartPingResource);
        ObjectMapperContext = typeof(SmartPingApplicationModule);
    }
}
