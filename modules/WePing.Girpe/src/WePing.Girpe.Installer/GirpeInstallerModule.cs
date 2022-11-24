using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace WePing.Girpe;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class GirpeInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<GirpeInstallerModule>();
        });
    }
}
