using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using WePing.SmartPing;
using WePing.Girpe;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using System;
using WePing.PointCalculator;

namespace WePing;

[DependsOn(
    typeof(WePingDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(WePingApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
    [DependsOn(typeof(SmartPingApplicationModule))]
    [DependsOn(typeof(GirpeApplicationModule))]
    [DependsOn(typeof(PointCalculatorApplicationModule))]
    public class WePingApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<WePingApplicationModule>();
        });
        //context.Services.AddMediatR(typeof(SmartPingApplicationModule).GetTypeInfo().Assembly, typeof(GirpeApplicationModule).GetTypeInfo().Assembly);
        //context.Services.AddMediatR(typeof(SmartPingApplicationModule).GetTypeInfo().Assembly,typeof(GirpeApplicationModule).GetTypeInfo().Assembly);
        //context.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

    }
}
