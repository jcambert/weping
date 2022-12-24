using System.Threading.Tasks;

namespace WePing.PointCalculator;

public interface ICalculateurPoints
{
    double Coeficient { get; set; }
    Task<double> CalculateAsync(double mePoints, double advPoints,bool victoire);
}
