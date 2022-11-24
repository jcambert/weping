using Volo.Abp.Modularity;

namespace WePing.SmartPing;

[DependsOn(
    typeof(SmartPingApplicationModule),
    typeof(SmartPingDomainTestModule)
    )]
public class SmartPingApplicationTestModule : AbpModule
{

}
