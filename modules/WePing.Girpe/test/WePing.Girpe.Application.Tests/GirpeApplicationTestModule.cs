using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using WePing.SmartPing;

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

        //context.Services.AddMediator();
        context.Services.AddMediatR(typeof(SmartPingApplicationModule).GetTypeInfo().Assembly, typeof(GirpeApplicationModule).GetTypeInfo().Assembly);
    }
}
