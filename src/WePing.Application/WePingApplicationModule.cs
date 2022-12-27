using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using WePing.Girpe;
using WePing.PointCalculator;
using WePing.SmartPing;

namespace WePing;

[DependsOn(
    typeof(WePingDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(WePingApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
    [DependsOn(typeof(SmartPingApplicationModule))]
    [DependsOn(typeof(GirpeApplicationModule))]
    [DependsOn(typeof(PointCalculatorApplicationModule))]
    public class WePingApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<WePingApplicationModule>();
        });

    }
}
