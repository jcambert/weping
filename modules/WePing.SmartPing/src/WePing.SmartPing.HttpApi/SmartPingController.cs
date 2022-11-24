using WePing.SmartPing.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace WePing.SmartPing;

public abstract class SmartPingController : AbpControllerBase
{
    protected SmartPingController()
    {
        LocalizationResource = typeof(SmartPingResource);
    }
}
