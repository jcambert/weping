using Volo.Abp.Modularity;

namespace WePing.PointCalculator;

[DependsOn(
    typeof(PointCalculatorApplicationModule),
    typeof(PointCalculatorDomainTestModule)
    )]
public class PointCalculatorApplicationTestModule : AbpModule
{

}
