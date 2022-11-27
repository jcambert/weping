using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
namespace WePing.SmartPing;

[DependsOn(
    typeof(SmartPingApplicationModule),
    typeof(SmartPingDomainTestModule)
    )]
public class SmartPingApplicationTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        context.Services.AddMediator();
    }
}
