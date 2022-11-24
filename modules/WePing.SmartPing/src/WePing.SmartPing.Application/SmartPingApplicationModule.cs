using Microsoft.Extensions.DependencyInjection;
using Polly.Extensions.Http;
using Polly;
using System.Net.Http;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using WePing.SmartPing.Spid;
using WePing.SmartPing.Domain.Clubs.Queries;
using WePing.SmartPing.Spid.Domain.Clubs.Queries;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using WePing.SmartPing.Spid.Domain.ClubDetails.Queries;
using WePing.SmartPing.Domain.Organismes.Queries;
using WePing.SmartPing.Spid.Domain.Organismes.Queries;
using System.Net.NetworkInformation;
using WePing.SmartPing.Spid.Handlers.Organismes;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Spid.Domain.Epreuves.Queries;
using WePing.SmartPing.Spid.Handlers.Epreuves;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Spid.Domain.Divisions.Queries;
using WePing.SmartPing.Spid.Handlers.Divisions;

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

        context.Services.AddMediator();
        context.Services.AddSingleton<IPipelineBehavior<BrowseOrganismeQuery, BrowseOrganismeResponse>, OrganismeValidator>();
        context.Services.AddSingleton<IPipelineBehavior<BrowseEpreuveQuery, BrowseEpreuveResponse>, EpreuveValidator>();
        context.Services.AddSingleton<IPipelineBehavior<BrowseDivisionQuery, BrowseDivisionResponse>, DivisionValidator>();
        context.Services.AddTransient(typeof(IDeserializeService<>),typeof( DeserializeService<>));
        context.Services.AddTransient<IBrowseClubsQuery, BrowseClubsQuery>();
        context.Services.AddTransient<IGetClubQuery, GetClubQuery>();
        context.Services.AddTransient<IGetClubDetailQuery, GetClubDetailQuery>();
        context.Services.AddTransient<IBrowseOrganismeQuery, BrowseOrganismeQuery>();
        context.Services.AddTransient<IBrowseEpreuveQuery, BrowseEpreuveQuery>();
        context.Services.AddTransient<IBrowseDivisionQuery, BrowseDivisionQuery>();
    }

    static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount)
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,retryAttempt)));
    }
}
