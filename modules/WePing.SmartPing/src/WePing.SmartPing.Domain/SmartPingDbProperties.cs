namespace WePing.SmartPing;

public static class SmartPingDbProperties
{
    public static string DbTablePrefix { get; set; } = "SmartPing";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "SmartPing";
}
