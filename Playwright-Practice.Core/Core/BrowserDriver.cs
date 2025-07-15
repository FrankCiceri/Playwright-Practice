using Microsoft.Playwright;
using Playwright_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Core.Core
{
    public class BrowserDriver : IBrowserDriver
    {
        private readonly IBrowser _browser;
        private readonly IPlaywright _playwright;
        

        public BrowserDriver(IBrowser browser, IPlaywright playwright)
        {
            _browser = browser ?? throw new ArgumentNullException(nameof(browser));
            _playwright = playwright ?? throw new ArgumentNullException(nameof(playwright));
           
        }

        public IBrowser Browser {get => _browser; }

        public async ValueTask DisposeAsync()
        {            
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        
    }
}
