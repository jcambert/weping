namespace WePing.PointCalculator;

public static class PointCalculatorDbProperties
{
    public static string DbTablePrefix { get; set; } = "PointCalculator";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "PointCalculator";
}
