using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using We.BasicTheme.Bundling;

namespace We.Components.Web.BasicTheme;

[DependsOn(typeof(AbpAspNetCoreComponentsWebThemingModule))]
public class WeComponentsWebBasicThemeModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);

      

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(WeBasicThemeBundles.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(WeBasicThemeBundles.Styles.Global)
                        .AddContributors(typeof(WeBasicThemeStyleContributor));
                });

            options
                .ScriptBundles
                .Add(WeBasicThemeBundles.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(WeBasicThemeBundles.Scripts.Global)
                        .AddContributors(typeof(WeBasicThemeScriptContributor));
                });
        });

    }
}


