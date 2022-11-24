using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace WePing.SmartPing;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class SmartPingInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SmartPingInstallerModule>();
        });
    }
}
