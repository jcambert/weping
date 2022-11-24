using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace WePing.SmartPing;

[DependsOn(
    typeof(SmartPingApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SmartPingHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SmartPingApplicationContractsModule).Assembly,
            SmartPingRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SmartPingHttpApiClientModule>();
        });

    }
}
