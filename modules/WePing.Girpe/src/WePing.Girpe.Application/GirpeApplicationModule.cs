using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using WePing.SmartPing;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Joueurs.Queries;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Handlers.Clubs;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace WePing.Girpe;

[DependsOn(
    typeof(GirpeDomainModule),
    typeof(GirpeApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
[DependsOn(typeof(SmartPingApplicationModule))]
public class GirpeApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<GirpeApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<GirpeApplicationModule>(validate: true);
           
        });
        context.Services.AddTransient<IBrowseClubQuery, BrowseClubQuery>();
        context.Services.AddTransient<IGetClubQuery, GetClubQuery>();
        context.Services.AddTransient<IBrowseJoueurQuery, BrowseJoueurQuery>();
        context.Services.AddTransient<IGetJoueurQuery,GetJoueurQuery>();
        
       /* context.Services.AddLogging(logger =>
        {
            logger.ClearProviders();
            logger.AddConsole();
        });*/
        //context.Services.AddMediator(typeof(GirpeApplicationModule).GetTypeInfo().Assembly);
        //context.Services.AddMediatR(typeof(GirpeApplicationModule).GetTypeInfo().Assembly);
    }
}
