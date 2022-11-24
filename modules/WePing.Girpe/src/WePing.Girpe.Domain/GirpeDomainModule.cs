using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace WePing.Girpe;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(GirpeDomainSharedModule)
)]
public class GirpeDomainModule : AbpModule
{

}
