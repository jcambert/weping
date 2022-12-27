using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;

namespace WePing.PointCalculator.Controllers;

[Area(PointCalculatorRemoteServiceConsts.ModuleName)]
[RemoteService(Name = PointCalculatorRemoteServiceConsts.RemoteServiceName)]
[Route("api/point/calc")]
public class PointCalcController : PointCalculatorController
{
    protected ICalculateurPoints _service => LazyServiceProvider.LazyGetRequiredService<ICalculateurPoints>();

    [HttpGet()]
    public Task<double> CalculateAsync(double mePoints, double advPoints, bool victoire)
    {
        _service.Coeficient = 1;
        return _service.CalculateAsync(mePoints, advPoints, victoire);
    }
}
