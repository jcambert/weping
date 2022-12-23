using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace WePing.PointCalculator;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class PointCalculatorInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PointCalculatorInstallerModule>();
        });
    }
}
