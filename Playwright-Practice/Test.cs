using Microsoft.Playwright;
using Playwright_Practice.Business;
using Playwright_Practice.Business.PageObjects.CareersPage;
using Playwright_Practice.Business.PageObjects.HeaderPage;
using Playwright_Practice.Core.Core;
using Playwright_Practice.Core.Interfaces;
using Playwright_Practice.UIHelper;
using System.Threading.Tasks;

namespace Playwright_Practice
{
    public class Tests
    {
        private IBrowserDriver _browserDriver;
        private IBrowserContext _browserContext;
        private IPage _page;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            var driverFactory = new BrowserFactory();
            _browserDriver = await driverFactory.CreateBrowserAsync();
        }

        [SetUp]
        public async Task Setup()
        {
            _browserContext = await _browserDriver.Browser.NewContextAsync();
            _page = await _browserContext.NewPageAsync();
            await _page.GotoAsync("https://www.epam.com");
        }

        [TestCase("Java")]
        public async Task Test1(string keyword)
        {
            var headerPage = new HeaderPage(_page);
            await UiHelpers.AcceptCookiesIfVisibleAsync(_page);
            await headerPage.ClickCareersLink();

            var careerPage = new CareersPage(_page);
            await careerPage.EnterSearchKeyword(keyword);


        }



        [TearDown]
        public async Task TearDown()
        {
            if (_browserContext is not null)
            {
                await _browserContext.CloseAsync();
            }
        }

        [OneTimeTearDown]
        public async Task CloseAll()
        {
            await _browserDriver.DisposeAsync();
        }

    }

}