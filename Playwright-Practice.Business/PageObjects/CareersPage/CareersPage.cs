using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Playwright_Practice.Core.ArgumentValidator.ArgumentValidator;

namespace Playwright_Practice.Business.PageObjects.CareersPage
{
    public partial class CareersPage
    {
        public CareersPage(IPage page)
        {
            if (page is null) throw new ArgumentNullException(nameof(page));
            _page = page;

        }

        public async Task EnterSearchKeyword(string keyword)
        {
            CheckArgumentIsNull(keyword, nameof(keyword));

            try
            {
                await CareerSearchTxtField.FillAsync(keyword);
                await CloseSuggestionsMenuIfVisible();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SelectLocationFromDropdown(string location)
        {
            CheckArgumentIsNull(location, nameof(location));
            await DeployLocationDropdown();
            await SelectDropdownLocation(location);
        }

        public async Task ClickRemoteCheckContainer()
        {
            try
            {
                while (!(await RemoteCheckbox.IsCheckedAsync()))
                {
                    await RemoteCheckContainer.ClickAsync();
                   
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ClickJobSearchButton()
        {
            try
            {
                await JobSearchButton.ClickAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
