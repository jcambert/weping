using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace WePing.SmartPing.Spid;

public class SpidRequestAppService:SmartPingAppService, ISpidRequestAppService
{
	internal const string HTTP_CLIENT_NAME = "SpidRequest";

	public HttpClient Client { get; init; }
    public ISpidAuthorizationBuilderAppService AuthService { get; init; }
    public SpidAuthorizationOptions AuthOptions { get; init; }
    public SpidRequestOptions RequestOptions { get; init; }
    public SpidEndPointsOptions EndPointsOptions { get; init; }

    public SpidRequestAppService(HttpClient httpClient,ISpidAuthorizationBuilderAppService authService,IOptions<SpidAuthorizationOptions> authOptions ,IOptions< SpidRequestOptions> requestOptions,IOptions<SpidEndPointsOptions> endPointsOptions)
	{
	
        Client=httpClient;
        AuthService = authService;
        AuthOptions=authOptions.Value; 
		RequestOptions = requestOptions.Value;
        EndPointsOptions = endPointsOptions.Value;

    }

	public async Task<byte[]> GetByteAsync(IBaseSpidRequestQuery query,string api_endpoint,CancellationToken cancellationToken=default)
	{
        var url =await  GetQueryAsync(query, api_endpoint);
        //Logger.Log(Microsoft.Extensions.Logging.LogLevel.Trace,)
        var resp = await Client.GetAsync(url, cancellationToken);
        return await resp.Content.ReadAsByteArrayAsync();
    }
    public async  Task<Stream> GetStreamAsync(IBaseSpidRequestQuery query, string api_endpoint, CancellationToken cancellationToken = default)
    {
        var url = await GetQueryAsync(query, api_endpoint);
        var resp = await Client.GetAsync(url,cancellationToken);
        return await resp.Content.ReadAsStreamAsync();
    }

    public async Task<string> GetAsync(IBaseSpidRequestQuery query, string api_endpoint, CancellationToken cancellationToken = default)
     {
        var url =await  GetQueryAsync(query, api_endpoint);
        var resp = await Client.GetAsync(url,cancellationToken);
        return await resp.Content.ReadAsStringAsync();
    }

   
    public async Task<string> GetQueryAsync(IBaseSpidRequestQuery query, string api_endpoint)
        => EndPointsOptions[api_endpoint] +await GetParameters(query.ToDictionnary());
    private async Task<string> GetParameters(IDictionary<string, string> opts = null)
    {
        var dico = new Dictionary<string, string>(opts);
        SpidAuthorization auth =await AuthService.GetAsync();
        dico["id"] = AuthOptions.AppId;
        dico["serie"] = AuthOptions.Serie;
        dico["tm"] = auth.Tm;
        dico["tmc"] =auth.Tmc;
        var result = QueryHelpers.AddQueryString("", dico);
        return result;
    }

 
}
