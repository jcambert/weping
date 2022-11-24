using Volo.Abp.Settings;

namespace WePing.Settings;

public class WePingSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(WePingSettings.MySetting1));
    }
}
