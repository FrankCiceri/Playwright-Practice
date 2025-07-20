using Microsoft.Playwright;
using Playwright_Practice.Core.Core;
using Playwright_Practice.Core.Interfaces;
using Playwright_Practice.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Playwright_Practice.Core.Utils.ArgumentValidator.ArgumentValidator;

namespace Playwright_Practice.Business.PageObjects.Components.JobSearchFilterComponent
{
    public partial class JobSearchFilterComponent
    {
        
        private async Task CloseSuggestionsMenuIfVisible()
        {
            try
            {
                try
                {
                    await CareerSuggestionsMenu.WaitForAsync(new LocatorWaitForOptions
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 2000
                    });
                }
                catch (TimeoutException)
                { 
                    Console.WriteLine("Suggestion Menu did not appear. Proceeding without issues.");
                }

                if (await CareerSuggestionsMenu.IsVisibleAsync())
                {
                    await CareerSearchTxtField.PressAsync(KeyboardKey.Escape);
                }
            }
            catch
            {
                throw;
            }
        }

        private async Task DeployLocationDropdown()
        {
            try
            {
                await LocationDropdown.WaitForAsync(new LocatorWaitForOptions()
                {
                    State = WaitForSelectorState.Visible,
                });

                await LocationDropdown.ClickAsync();
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"{nameof(LocationDropdown)} did not appear");
            }

        }       

        

        private async Task SelectDropdownLocation(string city)
        {
            try
            {
                await LocationDropdownOptions.WaitForAsync(new LocatorWaitForOptions()
                {
                    State = WaitForSelectorState.Visible,
                });

                await LocationCountryOption(city).ClickAsync();

                await LocationCityOption(city).ClickAsync();

            }
            catch (TimeoutException)
            {
                Console.WriteLine("Location not valid", city);
            }
        }

        private async Task EnterSearchKeyword(string keyword)
        {
            CheckArgumentIsNull(keyword, nameof(keyword));

            try
            {
                await CareerSearchTxtField.FillAsync(keyword);
                await CloseSuggestionsMenuIfVisible();
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Failed to fill keyword '{keyword}' into search field. Exception: {ex.Message}");
                throw;
            }
        }

        private async Task SelectLocationFromDropdown(string location)
        {
            CheckArgumentIsNull(location, nameof(location));
            await DeployLocationDropdown();
            await SelectDropdownLocation(location);
        }

        private async Task ClickRemoteCheckContainer()
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

        private async Task ClickJobSearchButton()
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
