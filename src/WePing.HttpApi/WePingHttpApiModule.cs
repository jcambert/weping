using Localization.Resources.AbpUi;
using WePing.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using WePing.SmartPing;
using WePing.Girpe;
using WePing.PointCalculator;

namespace WePing;

[DependsOn(
    typeof(WePingApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
    [DependsOn(typeof(SmartPingHttpApiModule))]
    [DependsOn(typeof(GirpeHttpApiModule))]
    [DependsOn(typeof(PointCalculatorHttpApiModule))]
    public class WePingHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<WePingResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
