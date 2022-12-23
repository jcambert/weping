using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace WePing.PointCalculator.Blazor.Menus;

public class PointCalculatorMenuContributor : IMenuContributor
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
        context.Menu.AddItem(new ApplicationMenuItem(PointCalculatorMenus.Prefix, displayName: "PointCalculator", "/PointCalculator", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
