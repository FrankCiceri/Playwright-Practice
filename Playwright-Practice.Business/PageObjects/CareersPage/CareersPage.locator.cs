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
        private ILocator CareerSearchTxtField => _page.Locator("#new_form_job_search-keyword");
        private ILocator CareerSuggestionsMenu => _page.Locator("form#jobSearchFilterForm .autocomplete-suggestions");
    }
}
