using Microsoft.Playwright;
using NUnit.Framework;
using Playwright_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Core.Core
{
    public class DriverFactory : IDriverFactory
    {
        

        public async Task<IDriverContext> CreateDriverAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await SelectBrowser(playwright, "chromium");
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = ViewportSize.NoViewport,
            });
            var page = await context.NewPageAsync();

            

            return new DriverContext(browser, context, page, playwright);
        }

        private async Task<IBrowser> SelectBrowser(IPlaywright playwright, string browser)
        {
            return browser.ToLower() switch
            {
                "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
                {
                    Headless = false,
                    Channel = "chrome",
                    Args = new[] { "--window-position=0,0", "--window-size=1920,1080" }
                }),
                "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions()
                {
                    Headless = false,
                    Channel = "firefox"                    
                }),
                _ => throw new NotSupportedException($"Unsupported browser: {browser}")
            };
        }
       
    }
}
