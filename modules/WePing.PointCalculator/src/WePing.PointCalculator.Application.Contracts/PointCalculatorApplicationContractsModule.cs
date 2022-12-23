using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace WePing.PointCalculator;

[DependsOn(
    typeof(PointCalculatorDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PointCalculatorApplicationContractsModule : AbpModule
{

}
