using WePing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace WePing.Permissions;

public class WePingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WePingPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(WePingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WePingResource>(name);
    }
}
