﻿using Microsoft.Playwright;
using Playwright_Practice.Business.PageObjects.BasePages;
using Playwright_Practice.Business.PageObjects.Components.JobSearchFilterComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.CareersPage
{
    public partial class CareersPage : BasePage
    {        
        public CareersPage(IPage page) : base(page) 
        {
        }

        public async Task SearchJobByFilterRemote(string keyword, string location)
        {
            await JobSearchFilter.SearchJobs(keyword, location, true);
        }
    }
}
