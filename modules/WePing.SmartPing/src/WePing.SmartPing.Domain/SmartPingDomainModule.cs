using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace WePing.SmartPing;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SmartPingDomainSharedModule)
)]
public class SmartPingDomainModule : AbpModule
{

}
