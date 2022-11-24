using WePing.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace WePing.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WePingEntityFrameworkCoreModule),
    typeof(WePingApplicationContractsModule)
    )]
public class WePingDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
