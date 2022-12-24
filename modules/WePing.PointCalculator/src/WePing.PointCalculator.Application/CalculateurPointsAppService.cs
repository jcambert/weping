using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;
using WeUtilities;

namespace WePing.PointCalculator;

[Dependency(ServiceLifetime.Scoped), ExposeServices(typeof(ICalculateurPoints))]
public class CalculateurPointsAppService : PointCalculatorAppService, ICalculateurPoints
{

    IBaremeProvider BaremesProvider => LazyServiceProvider.LazyGetRequiredService<IBaremeProvider>();

    public double Coeficient { get; set; } = 1;

    protected List<BaremeDto> Baremes { get; private set; } = new();
    public CalculateurPointsAppService()
    {

    }
    public async Task<double> CalculateAsync(double mePoints, double advPoints, bool victoire)
    {
        if (Baremes.Count() == 0)
        {
            Baremes = (await BaremesProvider.LoadAsync()).OrderBy(x => x.Ecart).ToList();
        }
        var ecart = Math.Abs(mePoints - advPoints);
        var bareme = Baremes.Where(x => x.Ecart >= ecart).FirstOrDefault();
        bareme.ThrowIfNull(o => CalculatorException.Ecart(ecart));
        var result = victoire switch
        {
            true => mePoints >= advPoints ? bareme.VictoireNormale : bareme.VictoireAnormale,
            false => mePoints >= advPoints ? bareme.DefaiteAnormale : bareme.DefaiteNormale
        };
        return result;
    }
}
