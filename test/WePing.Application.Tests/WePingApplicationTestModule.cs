using Volo.Abp.Modularity;

namespace WePing;

[DependsOn(
    typeof(WePingApplicationModule),
    typeof(WePingDomainTestModule)
    )]
public class WePingApplicationTestModule : AbpModule
{

}
