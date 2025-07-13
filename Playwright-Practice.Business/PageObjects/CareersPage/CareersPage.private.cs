using Microsoft.Playwright;
using Playwright_Practice.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.CareersPage
{
    public partial class CareersPage
    {
        private readonly IPage _page;


        private async Task CloseSuggestionsMenuIfVisible()
        {
            try
            {
                if (await CareerSuggestionsMenu.IsVisibleAsync())
                {
                    await _page.PressEscapeAsync();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
