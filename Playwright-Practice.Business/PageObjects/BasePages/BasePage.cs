using Microsoft.Playwright;
using Playwright_Practice.Business.PageObjects.Components.HeaderComponent;
using Playwright_Practice.Business.PageObjects.Components.JobSearchFilterComponent;
using Playwright_Practice.Core;
using Playwright_Practice.Core.Interfaces;
using Playwright_Practice.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Playwright_Practice.Business.PageObjects.BasePages
{
    public abstract class BasePage
    {
        protected readonly IPage Page;


        public IHeaderComponent Header => _header ??= new HeaderComponent(Page);
        

        private IHeaderComponent? _header;
        

        protected BasePage(IPage page)
        {
            Page = page;
        }


        public async Task NavigateToAsync(string url)
        {
            await Page.GotoAsync(url);
        }

        public async Task<string> GetPageTitleAsync()
        {
            return await Page.TitleAsync();
        }

        public async Task<string> GetPageUrlAsync()
        {
            return Page.Url;
        }

        public async Task ClickAsync(ILocator locator)
        {
            await locator.ClickAsync();
        }

        public async Task FillAsync(ILocator locator, string text)
        {
            await locator.FillAsync(text);
        }

        public async Task TakeScreenshotAsync(string filePath)
        {
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = filePath });
        }

        public async Task WaitForVisibleAsync(ILocator locator)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        }


        public async Task<bool> IsElementVisibleAsync(ILocator locator)
        {
            return await locator.IsVisibleAsync();
        }

        public async Task<bool> IsElementEnabledAsync(ILocator locator)
        {
            return await locator.IsEnabledAsync();
        }

        public async Task<bool> IsTextPresentAsync(ILocator locator, string text)
        {
            return (await locator.TextContentAsync())?.Contains(text) ?? false;
        }

    }
}
