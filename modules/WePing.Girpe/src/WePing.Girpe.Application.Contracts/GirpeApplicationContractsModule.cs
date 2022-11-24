using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace WePing.Girpe;

[DependsOn(
    typeof(GirpeDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class GirpeApplicationContractsModule : AbpModule
{

}
