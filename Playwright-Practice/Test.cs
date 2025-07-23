using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Playwright_Practice.Business;
using Playwright_Practice.Business.PageObjects.CareersPage;
using Playwright_Practice.Business.PageObjects.CareersPage.JobListingPage;
using Playwright_Practice.Business.PageObjects.HomePage;
using Playwright_Practice.Core.Core;
using Playwright_Practice.Core.Interfaces;
using Playwright_Practice.UIHelper;
using System.Reflection.Metadata.Ecma335;
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
            var browserFactory = new BrowserFactory();
            _browserDriver = await browserFactory.CreateBrowserAsync();
        }

        [SetUp]
        public async Task Setup()
        {
            _browserContext = await _browserDriver.Browser.NewContextAsync(new BrowserNewContextOptions()
            {
                ViewportSize = ViewportSize.NoViewport
            });
            _page = await _browserContext.NewPageAsync();
            await _page.GotoAsync("https://www.epam.com");
            await UiHelpers.AcceptCookiesIfVisibleAsync(_page);
        }

        [TestCase("Python", "Buenos Aires")]
        public async Task Test_SearchJobsViaHeaderAndCareersPage(string keyword, string location)
        {            

            var homePage = new HomePage(_page);
            await homePage.NavigateToCareersPageFromHeader();            

            var careerPage = new CareersPage(_page);
            await careerPage.SearchJobByFilterRemote(keyword, location);

            var jobListingPage = new JobListingPage(_page);
            await jobListingPage.SortByDate();
            await jobListingPage.ApplyToFirstPositionInList();

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