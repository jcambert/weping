using System;
using System.Collections.Generic;
using System.Text;
using WePing.Localization;
using Volo.Abp.Application.Services;

namespace WePing;

/* Inherit your application services from this class.
 */
public abstract class WePingAppService : ApplicationService
{
    protected WePingAppService()
    {
        LocalizationResource = typeof(WePingResource);
    }
}
