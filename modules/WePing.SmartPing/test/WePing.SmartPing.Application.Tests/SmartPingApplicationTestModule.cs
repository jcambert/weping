using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

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
        context.Services.AddMediatR(typeof(SmartPingApplicationModule).GetTypeInfo().Assembly);
    }
}
