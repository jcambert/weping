using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace WePing;

[Dependency(ReplaceServices = true)]
public class WePingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "WePing";
}
