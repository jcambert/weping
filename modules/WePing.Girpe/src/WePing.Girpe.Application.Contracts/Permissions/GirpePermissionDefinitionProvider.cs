using WePing.Girpe.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace WePing.Girpe.Permissions;

public class GirpePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(GirpePermissions.GroupName, L("Permission:Girpe"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GirpeResource>(name);
    }
}
