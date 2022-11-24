using WePing.Localization;
using Volo.Abp.AspNetCore.Components;

namespace WePing.Blazor;

public abstract class WePingComponentBase : AbpComponentBase
{
    protected WePingComponentBase()
    {
        LocalizationResource = typeof(WePingResource);
    }
}
