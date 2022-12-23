using Volo.Abp.Reflection;

namespace WePing.PointCalculator.Permissions;

public class PointCalculatorPermissions
{
    public const string GroupName = "PointCalculator";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(PointCalculatorPermissions));
    }
}
