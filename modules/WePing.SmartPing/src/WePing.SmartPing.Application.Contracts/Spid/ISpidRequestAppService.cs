using System.IO;
using System.Threading;

namespace WePing.SmartPing.Spid;

public interface ISpidRequestAppService:IApplicationService
{
    Task<byte[]> GetByteAsync(IBaseSpidRequestQuery query, string api_endpoint, CancellationToken cancellationToken ) ;

    Task<Stream> GetStreamAsync(IBaseSpidRequestQuery query, string api_endpoint, CancellationToken cancellationToken);

    Task<string> GetAsync(IBaseSpidRequestQuery query, string api_endpoint, CancellationToken cancellationToken);

    Task<string> GetQueryAsync(IBaseSpidRequestQuery query, string api_endpoint);
    
}
