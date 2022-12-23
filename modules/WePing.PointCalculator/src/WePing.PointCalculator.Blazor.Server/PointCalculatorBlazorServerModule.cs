using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace WePing.PointCalculator.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(PointCalculatorBlazorModule)
    )]
public class PointCalculatorBlazorServerModule : AbpModule
{

}
