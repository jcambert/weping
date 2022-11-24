using Volo.Abp.Reflection;

namespace WePing.SmartPing.Permissions;

public class SmartPingPermissions
{
    public const string GroupName = "SmartPing";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SmartPingPermissions));
    }
}
