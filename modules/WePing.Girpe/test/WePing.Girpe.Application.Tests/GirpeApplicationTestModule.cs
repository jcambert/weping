using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
namespace WePing.Girpe;

[DependsOn(
    typeof(GirpeApplicationModule),
    typeof(GirpeDomainTestModule)
    )]
public class GirpeApplicationTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);

        context.Services.AddMediator();
    }
}
