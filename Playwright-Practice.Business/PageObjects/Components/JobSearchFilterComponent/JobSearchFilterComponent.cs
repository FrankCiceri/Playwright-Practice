using Microsoft.Playwright;
using Playwright_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Playwright_Practice.Business.PageObjects.Components.JobSearchFilterComponent
{
    public partial class JobSearchFilterComponent : BaseComponent, ISearchable
    {
        public JobSearchFilterComponent(IPage page) : base(page)
        {
        }

        public async Task SearchJobs(string keyword = "", string location = "", bool isRemote = false)
        {
            if (!string.IsNullOrEmpty(keyword)) await EnterSearchKeyword(keyword);
            if (!string.IsNullOrEmpty(location)) await SelectLocationFromDropdown(location);
            if (isRemote) await ClickRemoteCheckContainer();
            await ClickJobSearchButton();
        }

    }
}
