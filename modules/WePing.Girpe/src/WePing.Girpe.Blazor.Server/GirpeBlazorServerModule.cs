using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace WePing.Girpe.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(GirpeBlazorModule)
    )]
public class GirpeBlazorServerModule : AbpModule
{

}
