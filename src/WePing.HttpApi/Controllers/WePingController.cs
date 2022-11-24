using WePing.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace WePing.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class WePingController : AbpControllerBase
{
    protected WePingController()
    {
        LocalizationResource = typeof(WePingResource);
    }
}
