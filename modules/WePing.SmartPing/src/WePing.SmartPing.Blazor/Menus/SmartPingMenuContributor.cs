using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace WePing.SmartPing.Blazor.Menus;

public class SmartPingMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(SmartPingMenus.Prefix, displayName: "SmartPing", "/SmartPing", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
