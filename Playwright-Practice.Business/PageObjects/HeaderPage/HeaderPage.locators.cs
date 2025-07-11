using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.HeaderPage
{
    public partial class HeaderPage
    {
        private ILocator CareersButton => _page.Locator("a[class*= 'top-navigation__item-link'][href*='/careers']");

    }
}
