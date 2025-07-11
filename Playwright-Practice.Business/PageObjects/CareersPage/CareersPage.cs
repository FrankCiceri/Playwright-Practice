using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.CareersPage
{
    public partial class CareersPage
    {
        public CareersPage(IPage page)
        {
            if (page is null) throw new ArgumentNullException(nameof(page));
            _page = page;

        }

        public async Task EnterSearchKeyword(string keyword)
        {

        }
    }
}
