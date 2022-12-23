using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace WePing.PointCalculator;

[DependsOn(
    typeof(PointCalculatorApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class PointCalculatorHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(PointCalculatorApplicationContractsModule).Assembly,
            PointCalculatorRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PointCalculatorHttpApiClientModule>();
        });

    }
}
