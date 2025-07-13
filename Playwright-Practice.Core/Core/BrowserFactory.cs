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
    public class BrowserFactory : IBrowserFactory
    {
        

        public async Task<IBrowserDriver> CreateBrowserAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await SelectBrowser(playwright, "chromium");

            return new BrowserDriver(browser, playwright);
        }

        private async Task<IBrowser> SelectBrowser(IPlaywright playwright, string browser)
        {
            return browser.ToLower() switch
            {
                "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
                {
                    Headless = false,
                    Channel = "chrome",
                    Args = new List<string>() { "--start-maximized" }
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
