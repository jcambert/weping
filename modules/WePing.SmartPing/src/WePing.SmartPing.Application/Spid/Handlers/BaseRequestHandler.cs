using WePing.SmartPing.Domain.Clubs.Domain;

namespace WePing.SmartPing.Spid.Handlers;

public abstract class BaseRequestHandler<TQuery, TResponse, TDomain> : IRequestHandler<TQuery, TResponse>
    where TQuery : class, ISpidRequestQuery<TResponse>
    where TResponse:Response
{

    public ISpidRequestAppService RequestService { get; init; }
    public IDeserializeService<TDomain> Deserializer { get; init; }
   
    public BaseRequestHandler(ISpidRequestAppService requestService, IDeserializeService<TDomain> deserializer) => (RequestService, Deserializer) = (requestService, deserializer);
    //public abstract ValueTask<TResponse> Handle(TQuery request, CancellationToken cancellationToken);

    public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
}
