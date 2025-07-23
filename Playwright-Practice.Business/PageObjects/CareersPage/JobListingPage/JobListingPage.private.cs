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

namespace Playwright_Practice.Business.PageObjects.CareersPage.JobListingPage
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

        private int _loadedPositions;

        private async Task<int> GetNumberOfPositionsLoaded()
        {
           return await JobList.CountAsync();
        }

        private async Task ClickDateSortButton()
        {
            await ClickAsync(SortByDateBtn);
        }

        private async Task ApplytoCurrentPosition(ILocator positionLocator)
        {
           var applyBtn = ApplyBtn(positionLocator);
           await ClickAsync(applyBtn);
        }

        private async Task<ILocator> GetNthPosition(int positionIndex)
        {
            var positionsLoaded = await GetNumberOfPositionsLoaded();
            if (positionIndex < 0 && positionIndex > positionsLoaded - 1)
            {
                throw new IndexOutOfRangeException($"Select a valid index for the job positions loaded: {nameof(positionIndex)}" );
            }

            var position = JobList.Nth(positionIndex);
            return position;
        }
                
    }
}
