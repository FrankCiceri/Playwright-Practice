using Microsoft.Playwright;
using Playwright_Practice.Business.PageObjects.BasePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.CareersPage.JobListingPage
{
    public partial class JobListingPage : BasePage
    {
        public JobListingPage(IPage page) : base(page)
        {
        }

        public async Task SearchJobByFilterRemote(string keyword, string location)
        {
            await JobSearchFilter.SearchJobs(keyword, location, true);
        }

        public async Task SortByDate()
        {
            await ClickDateSortButton();
        }

        public async Task ApplyToFirstPositionInList()
        {
            var first = 0;
            var position = await GetNthPosition(first);
            await ApplytoCurrentPosition(position);
        }
    }
}
