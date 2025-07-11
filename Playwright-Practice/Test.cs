using Microsoft.Playwright;
using Playwright_Practice.Business;
using Playwright_Practice.Business.PageObjects.HeaderPage;
using Playwright_Practice.Core.Core;
using Playwright_Practice.Core.Interfaces;
using Playwright_Practice.UIHelper;
using System.Threading.Tasks;

namespace Playwright_Practice
{
    public class Tests
    {
        private IDriverContext _context;

        [SetUp]
        public async Task Setup()
        {
            var driverFactory = new DriverFactory();
            _context = await driverFactory.CreateDriverAsync();
            await _context.NavigateToAsync("https://www.epam.com");
        }

        [Test]
        public async Task Test1()
        {
            var headerPage = new HeaderPage(_context.Page);
            await UiHelpers.AcceptCookiesIfVisibleAsync(_context.Page);
            await headerPage.ClickCareersLink();
            
            
        }



        [TearDown]
        public async Task TearDown()
        {
            if (_context is not null)
            {
                await _context.DisposeAsync();
            }            
        }
    }
}