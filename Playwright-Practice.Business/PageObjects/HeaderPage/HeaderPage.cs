using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.HeaderPage
{
    public partial class HeaderPage
    {
        public HeaderPage(IPage page)
        {
            if (page is null) throw new ArgumentNullException(nameof(page));
            _page = page;

        }

        public async Task ClickCareersLink()
        {
            try
            {                
                await CareersButton.ClickAsync();
                await _page.WaitForLoadStateAsync();
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
