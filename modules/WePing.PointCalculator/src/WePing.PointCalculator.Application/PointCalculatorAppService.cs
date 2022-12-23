using WePing.PointCalculator.Localization;
using Volo.Abp.Application.Services;

namespace WePing.PointCalculator;

public abstract class PointCalculatorAppService : ApplicationService
{
    protected PointCalculatorAppService()
    {
        LocalizationResource = typeof(PointCalculatorResource);
        ObjectMapperContext = typeof(PointCalculatorApplicationModule);
    }
}
