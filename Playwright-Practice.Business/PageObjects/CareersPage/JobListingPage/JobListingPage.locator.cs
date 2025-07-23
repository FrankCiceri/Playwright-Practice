using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.CareersPage.JobListingPage
{
    public partial class JobListingPage
    {
        private ILocator SortByDateBtn => Page.GetByTitle("Date");
        private ILocator JobList => Page.Locator(".search-result__list > li");

        private ILocator ApplyBtn(ILocator locator) => locator.GetByText("View and Apply");
    }
}
