using WePing.SmartPing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace WePing.SmartPing.Permissions;

public class SmartPingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SmartPingPermissions.GroupName, L("Permission:SmartPing"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SmartPingResource>(name);
    }
}
