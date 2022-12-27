using Localization.Resources.AbpUi;
using WePing.PointCalculator.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace WePing.PointCalculator;

[DependsOn(
    typeof(PointCalculatorApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class PointCalculatorHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PointCalculatorHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PointCalculatorResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });

       /* Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options
                .ConventionalControllers
                
                .Create(typeof(PointCalculatorApplicationModule).Assembly);
        });*/
    }
}
