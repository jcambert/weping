using WePing.Girpe.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace WePing.Girpe;

public abstract class GirpeController : AbpControllerBase
{
    protected GirpeController()
    {
        LocalizationResource = typeof(GirpeResource);
    }
}
