using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.Components.HeaderComponent
{
    public partial class HeaderComponent
    {
        private ILocator CareersButton => Page.Locator("a[class*= 'top-navigation__item-link'][href*='/careers']");

        private ILocator CareersNavigationLink => Page.Locator("li").Filter(new LocatorFilterOptions
        {
            Has = CareersButton,
        });

        private ILocator CareersMenu => CareersNavigationLink.Locator(".top-navigation__flyout");

        private ILocator MenuItem(string itemName) => CareersMenu.Locator("li").Filter(new LocatorFilterOptions()
        {
            HasText = itemName
        });

        private ILocator JoinOurTeamButton => MenuItem("Join our Team");


    }
}
