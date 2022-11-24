﻿using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace WePing.Girpe;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(GirpeHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class GirpeConsoleApiClientModule : AbpModule
{

}
