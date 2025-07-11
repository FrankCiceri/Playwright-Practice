using Microsoft.Playwright;
using Playwright_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Core.Core
{
    public class DriverContext : IDriverContext
    {
        private readonly IBrowser _browser;
        private readonly IPlaywright _playwright;

        public IBrowserContext Context { get; }

        public IPage Page { get; }

        public DriverContext(IBrowser browser, IBrowserContext context, IPage page, IPlaywright playwright)
        {
            _browser = browser ?? throw new ArgumentNullException(nameof(browser));
            _playwright = playwright ?? throw new ArgumentNullException(nameof(playwright));
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Page = page ?? throw new ArgumentNullException(nameof(page));            
        }

        public async ValueTask DisposeAsync()
        {
            await Page.CloseAsync();
            await Context.CloseAsync();
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        public async Task NavigateToAsync(string url)
        {
            await Page.GotoAsync(url);
        }
    }
}
