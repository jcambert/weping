using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace WePing.SmartPing.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(SmartPingBlazorModule)
    )]
public class SmartPingBlazorServerModule : AbpModule
{

}
