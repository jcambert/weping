using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace WePing.PointCalculator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(PointCalculatorHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class PointCalculatorConsoleApiClientModule : AbpModule
{

}
