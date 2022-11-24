using WePing.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace WePing;

[DependsOn(
    typeof(WePingEntityFrameworkCoreTestModule)
    )]
public class WePingDomainTestModule : AbpModule
{

}
