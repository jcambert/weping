using WePing.PointCalculator.Localization;
using Volo.Abp.Application.Services;
namespace WePing.PointCalculator;

public abstract class PointCalculatorAppService : ApplicationService
{
    protected PointCalculatorAppService()
    {
        LocalizationResource = typeof(PointCalculatorResource);
        ObjectMapperContext = typeof(PointCalculatorApplicationModule);
    }
}
/*
 //@see https://github.com/jcambert/WePingOld/blob/master/WePing.domain/src/WePing.domain/Services/ICalculateurPoints.cs
public enum VictoireDefaite
{
    [Description("Victoire")]
    V = 0,
    [Description("Defaite")]
    D = 1
}
public interface ICalculateurPoints
{
    double Calculate(double mePoints, double advPoints, VictoireDefaite meVd);
}

public class CalculateurPoints : ICalculateurPoints
{
    private readonly ILogger<CalculateurPoints> _logger;
    private readonly GrillePoints _grille;
    const string GRILLE_POINT = "grille_points";
    readonly List<int> keys = new List<int>();
    public CalculateurPoints(IConfiguration config, ILogger<CalculateurPoints> logger)
    {
        this._logger = logger;
        try
        {
            _grille = config.GetOptions<GrillePoints>(GRILLE_POINT);
            _grille.Grille.Keys.ToList().ForEach(k => keys.Add(int.Parse(k)));
        }
        catch (Exception e)
        {
            _logger.LogError($"YOU MUST DEFINE grille_points IN YOUR appsettings.json file\n\t{e.Message}");
        }
    }
    public double Calculate(double mePoints, double advPoints, VictoireDefaite meVd)
    {
        var ecart = Math.Abs(mePoints - advPoints);


        var key = keys.OrderBy(k => k).Where(k => k >= ecart).FirstOrDefault();
        var vd = _grille[key];
        if (meVd == VictoireDefaite.V)
        {
            return mePoints >= advPoints ? vd.vn : vd.va;
        }
        else
        {
            return mePoints >= advPoints ? vd.da : vd.dn;
        }

    }
}

public class GrillePoints
{
    public GrillePoints()
    {

    }
    public Dictionary<string, VDPoint> Grille { get; set; }

    public VDPoint this[int key]
    {
        get
        {
            return Grille[key.ToString()];
        }
    }
}
public class VDPoint
{

#pragma warning disable IDE1006 // Styles d'affectation de noms
    public double vn { get; set; }

    public double va { get; set; }
    public double dn { get; set; }
    public double da { get; set; }

    public override string ToString()
    {
        return $"Victoire Normale:{vn} / Defaite Normale:{dn} / Victoire Anormale:{va} / Defaite Anormale:{da}";
    }
#pragma warning restore IDE1006 // Styles d'affectation de noms
}*/