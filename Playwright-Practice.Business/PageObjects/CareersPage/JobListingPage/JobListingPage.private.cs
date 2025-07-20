using Microsoft.Playwright;
using Playwright_Practice.Business.PageObjects.Components.JobSearchFilterComponent;
using Playwright_Practice.Core.Core;
using Playwright_Practice.Core.Interfaces;
using Playwright_Practice.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.CareersPage
{
    public partial class JobListingPage
    {
        private ISearchable? _jobSearchFilter;

        private ISearchable JobSearchFilter
        {
            get
            {
                _jobSearchFilter ??= new JobSearchFilterComponent(Page);
                return _jobSearchFilter;
            }
        }

    }
}
