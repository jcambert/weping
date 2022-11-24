using WePing.SmartPing.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace WePing.SmartPing;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(SmartPingEntityFrameworkCoreTestModule)
    )]
public class SmartPingDomainTestModule : AbpModule
{

}
