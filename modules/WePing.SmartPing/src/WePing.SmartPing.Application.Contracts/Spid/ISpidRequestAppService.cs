using System.IO;
using System.Threading;

namespace WePing.SmartPing.Spid;

public interface ISpidRequestAppService:IApplicationService
{
    Task<byte[]> GetByteAsync(ISpidRequestQuery query, string api_endpoint, CancellationToken cancellationToken );

    Task<Stream> GetStreamAsync(ISpidRequestQuery query, string api_endpoint, CancellationToken cancellationToken);

    Task<string> GetAsync(ISpidRequestQuery query, string api_endpoint, CancellationToken cancellationToken);

    Task<string> GetQueryAsync(ISpidRequestQuery query, string api_endpoint);
}
