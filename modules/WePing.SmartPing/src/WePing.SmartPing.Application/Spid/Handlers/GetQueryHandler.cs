using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.SmartPing.Spid.Handlers;

public class GetQueryHandler : IRequestHandler<GetQuery, SpidRequestResponse>
{
    protected readonly ISpidRequestAppService _requestService;

    public GetQueryHandler(ISpidRequestAppService requestService)
    {
        this._requestService=requestService;
    }
    public async ValueTask<SpidRequestResponse> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var result = await _requestService.GetQueryAsync(request.Query,request.EndPoint);
        
        return new SpidRequestResponse(result);
    }
}
