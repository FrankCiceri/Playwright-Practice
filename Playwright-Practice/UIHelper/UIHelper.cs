using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.UIHelper
{
    public static class UiHelpers
    {
        public static async Task AcceptCookiesIfVisibleAsync(IPage page)
        {
            var cookieBtn = page.Locator("#onetrust-accept-btn-handler");

            if (await cookieBtn.IsVisibleAsync())
            {
                await cookieBtn.ClickAsync();
                await cookieBtn.WaitForAsync(new() { State = WaitForSelectorState.Hidden });
            }
        }
    }
}
