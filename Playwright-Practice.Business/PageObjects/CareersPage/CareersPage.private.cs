using Microsoft.Playwright;
using Playwright_Practice.Core.Core;
using Playwright_Practice.Core.Utils;
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

        //private async Task SelectLocation(string location)
        //{
        //    try
        //    {
                
        //    }
        //    catch (TimeoutException)
        //    {
        //        Console.WriteLine("Location not valid", location);
        //    }

        //}


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
    }
}
