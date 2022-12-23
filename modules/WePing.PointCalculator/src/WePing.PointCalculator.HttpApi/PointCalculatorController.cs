using WePing.PointCalculator.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace WePing.PointCalculator;

public abstract class PointCalculatorController : AbpControllerBase
{
    protected PointCalculatorController()
    {
        LocalizationResource = typeof(PointCalculatorResource);
    }
}
