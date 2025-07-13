using Microsoft.Playwright;
using Playwright_Practice.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Core.Core
{
    public static class PageExtensionMethod
    {

        public static async Task PressEscapeAsync(this IPage page)
        {
            try
            {
                await page.Keyboard.PressAsync(KeyboardKey.Escape);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
