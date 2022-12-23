using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace WePing.PointCalculator;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(PointCalculatorDomainSharedModule)
)]
public class PointCalculatorDomainModule : AbpModule
{

}
