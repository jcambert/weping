using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Application.Services;
using System;

namespace WePing.PointCalculator;


public interface IBaremeAppService:/*IApplicationService*/ICrudAppService<BaremeDto,Guid>
{
    //Task<BaremeDto> CreateAsync(BaremeDto bareme/*, CancellationToken cancellationToken = default*/);
}
