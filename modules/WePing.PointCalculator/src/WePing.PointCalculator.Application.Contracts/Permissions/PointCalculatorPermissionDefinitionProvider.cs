using WePing.PointCalculator.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace WePing.PointCalculator.Permissions;

public class PointCalculatorPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PointCalculatorPermissions.GroupName, L("Permission:PointCalculator"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PointCalculatorResource>(name);
    }
}
