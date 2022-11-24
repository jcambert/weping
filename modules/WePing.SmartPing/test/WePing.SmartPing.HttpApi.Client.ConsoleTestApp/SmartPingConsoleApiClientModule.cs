using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace WePing.SmartPing;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SmartPingHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SmartPingConsoleApiClientModule : AbpModule
{

}
