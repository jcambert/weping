using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace We.BasicTheme.Bundling;

public  class WeBasicThemeStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/_content/We.BasicTheme/libs/we/css/theme.css");
    }
}
