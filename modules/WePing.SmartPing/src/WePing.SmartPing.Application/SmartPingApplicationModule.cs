using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using WePing.SmartPing.Domain.Clubs.Queries;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Domain.Organismes.Queries;
using WePing.SmartPing.Spid;
using WePing.SmartPing.Spid.Domain.ClubDetails.Queries;
using WePing.SmartPing.Spid.Domain.Clubs.Queries;
using WePing.SmartPing.Spid.Domain.Divisions.Queries;
using WePing.SmartPing.Spid.Domain.Epreuves.Queries;
using WePing.SmartPing.Spid.Domain.Joueurs.Queries;
using WePing.SmartPing.Spid.Domain.Organismes.Queries;
using WePing.SmartPing.Spid.Handlers.Divisions;
using WePing.SmartPing.Spid.Handlers.Epreuves;
using WePing.SmartPing.Spid.Handlers.Joueurs;
using WePing.SmartPing.Spid.Handlers.Organismes;

namespace WePing.SmartPing;

[DependsOn(
    typeof(SmartPingDomainModule),
    typeof(SmartPingApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class SmartPingApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        context.Services.AddAutoMapperObjectMapper<SmartPingApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SmartPingApplicationModule>(validate: true);
        });

        Configure<SpidAuthorizationOptions>(configuration.GetSection("SpidAuthorization"));
        Configure<SpidRequestOptions>(configuration.GetSection("SpidRequest"));
        Configure<SpidEndPointsOptions>(configuration.GetSection("Spid"));
        var baseUrl = configuration["spid:endpoint"];
        var httpLifetime = configuration["spidrequest:HttpLifetime"].To<double>();
        var retryCount = configuration["spidrequest:RetryCount"].To<int>();
        context.Services.AddHttpClient();
        context.Services
            .AddHttpClient<ISpidRequestAppService, SpidRequestAppService>(SpidRequestAppService.HTTP_CLIENT_NAME, client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            })
            .SetHandlerLifetime(TimeSpan.FromSeconds(httpLifetime))
            .AddPolicyHandler(GetRetryPolicy(retryCount));

        
        
        

        context.Services.AddTransient(typeof(IDeserializeService<>), typeof(DeserializeService<>));

        context.Services
            .RegisterValidators()
            .RegisterQueries();

       // context.Services.AddMediatR(typeof(SmartPingApplicationModule).GetType().Assembly);
    }

    static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount)
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,retryAttempt)));
    }
}

internal static class SmartPingApplicationModuleExtension
{
    internal static IServiceCollection RegisterQueries(this IServiceCollection services)
    {
        
        services.AddTransient<IBrowseClubsQuery, BrowseClubsQuery>();
        services.AddTransient<IGetClubQuery, GetClubQuery>();
        services.AddTransient<IGetClubDetailQuery, GetClubDetailQuery>();
        services.AddTransient<IBrowseOrganismeQuery, BrowseOrganismeQuery>();
        services.AddTransient<IBrowseEpreuveQuery, BrowseEpreuveQuery>();
        services.AddTransient<IBrowseDivisionQuery, BrowseDivisionQuery>();
        services.AddTransient<IBrowseJoueurClassementQuery, BrowseJoueurClassementQuery>();
        services.AddTransient<IGetJoueurDetailClassementQuery, GetJoueurDetailClassementQuery>();
        services.AddTransient<IGetJoueurDetailSpidQuery, GetJoueurDetailSpidQuery>();
        services.AddTransient<IGetJoueurDetailSpidClaQuery, GetJoueurDetailSpidClaQuery>();
        services.AddTransient<IBrowseJoueurDetailSpidClaQuery, BrowseJoueurDetailSpidClaQuery>();
        services.AddTransient<IBrowseJoueurSpidQuery, BrowseJoueurSpidQuery>();
        services.AddTransient<IGetQuery, GetQuery>();
        return services;
    }

    internal static IServiceCollection RegisterValidators(this IServiceCollection services)
    {
        services.AddSingleton<IPipelineBehavior<BrowseOrganismeQuery, BrowseOrganismeResponse>, OrganismeValidator>();
        services.AddSingleton<IPipelineBehavior<BrowseEpreuveQuery, BrowseEpreuveResponse>, EpreuveValidator>();
        services.AddSingleton<IPipelineBehavior<BrowseDivisionQuery, BrowseDivisionResponse>, DivisionValidator>();
        services.AddSingleton<IPipelineBehavior<BrowseJoueurClassementQuery, BrowseJoueurClassementResponse>, JoueurClassementValidator>();
        services.AddSingleton<IPipelineBehavior<GetJoueurDetailClassementQuery, GetJoueurDetailClassementResponse>, JoueurDetailClassementValidator>();
        services.AddSingleton<IPipelineBehavior<GetJoueurDetailSpidQuery, GetJoueurDetailSpidResponse>, JoueurDetailSpidValidator>();
        services.AddSingleton<IPipelineBehavior<BrowseJoueurSpidQuery, BrowseJoueurSpidResponse>, JoueurSpidValidator>();
        return services;
    }
}