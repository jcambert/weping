using Localization.Resources.AbpUi;
using WePing.SmartPing.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace WePing.SmartPing;

[DependsOn(
    typeof(SmartPingApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SmartPingHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SmartPingHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SmartPingResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
