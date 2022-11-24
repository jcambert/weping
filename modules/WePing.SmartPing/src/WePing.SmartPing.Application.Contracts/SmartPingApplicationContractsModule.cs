using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace WePing.SmartPing;

[DependsOn(
    typeof(SmartPingDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class SmartPingApplicationContractsModule : AbpModule
{

}
