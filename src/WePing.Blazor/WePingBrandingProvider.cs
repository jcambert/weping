using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace WePing.Blazor;

[Dependency(ReplaceServices = true)]
public class WePingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "WePing";
}
