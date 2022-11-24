using Volo.Abp.Modularity;

namespace WePing.Girpe;

[DependsOn(
    typeof(GirpeApplicationModule),
    typeof(GirpeDomainTestModule)
    )]
public class GirpeApplicationTestModule : AbpModule
{

}
