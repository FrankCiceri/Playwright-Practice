

using Microsoft.Playwright;
using Playwright_Practice.Business.PageObjects.BasePages;

namespace Playwright_Practice.Business.PageObjects.HomePage
{
    public partial class HomePage : BasePage
    {        
        public HomePage(IPage page) : base(page)
        {         
        }

        public async Task NavigateToCareersPageFromHeader()
        {
            await Header.NavigateToCareersPage();
        }

    }
}
