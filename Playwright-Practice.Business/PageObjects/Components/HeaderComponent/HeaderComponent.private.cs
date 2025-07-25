﻿using Microsoft.Playwright;
using Playwright_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.Components.HeaderComponent
{
    public partial class HeaderComponent
    {

        //private async Task WaitForNavLinkShowsMenu(ILocator navlink)
        //{
        //    const string openedMenuClassname = "top-navigation__item epam js-opened";
        //    const int timeout = 10000;

        //    await navlink.Page.WaitForFunctionAsync(
        //@"(elementAndClass) => {
        //    const [element, expectedClass] = elementAndClass;
        //    return element.className === expectedClass;
        //}",
        //new object[] { navlink, openedMenuClassname },
        //new() { Timeout = timeout });
        //}


        private async Task WaitForNavLinkShowsMenu(ILocator navlink)
        {
            const string expectedClassName = "top-navigation__item epam js-opened";


           await Assertions.Expect(navlink).ToHaveAttributeAsync("class", expectedClassName, new() { Timeout = 10000 });

        }


        private async Task HoverCareersLink()
        {
            try
            {
                await CareersButton.HoverAsync();
                await CareersMenu.WaitForAsync(new LocatorWaitForOptions()
                {
                    State = WaitForSelectorState.Visible
                });

            }
            catch (TimeoutException)
            {
                throw;
            }
        }

        private async Task ClickCareersLink()
        {
            try
            {
                await CareersButton.ClickAsync();
                await Page.WaitForLoadStateAsync();

                //await WaitForNavLinkShowsMenu(CareersNavigationLink);

            }
            catch (TimeoutException)
            {
                throw;
            }
        }

        private async Task ClickJoinOurTeamButton()
        {
            try
            {
                await JoinOurTeamButton.ClickAsync();
                await Page.WaitForLoadStateAsync();
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"Failed to click the 'Join Our Team' button within the ms or the page failed to load.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error while clicking the 'Join Our Team' button: {ex.Message}", ex);
            }
        }


    }
}
