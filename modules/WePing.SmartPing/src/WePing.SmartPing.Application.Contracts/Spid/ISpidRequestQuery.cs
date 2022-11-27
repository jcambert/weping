using Mediator;

namespace WePing.SmartPing.Spid;
public interface IBaseSpidRequestQuery { }
public interface ISpidRequestQuery<T> : IBaseSpidRequestQuery, IRequest<T>
    where T : Response
{
}

public interface ISpidRequestQuery: ISpidRequestQuery<SpidRequestResponse>
{
}

public record Response();
public sealed record SpidRequestResponse(string response):Response;
