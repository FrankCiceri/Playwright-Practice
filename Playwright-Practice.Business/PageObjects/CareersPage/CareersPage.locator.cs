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

        private ILocator RemoteCheckbox => _page.GetByRole(AriaRole.Checkbox, new() { Name = "Remote" });
        private ILocator RemoteCheckContainer => _page.Locator("p").Filter(new LocatorFilterOptions
        {
            Has = RemoteCheckbox
        });

        private ILocator LocationDropdown => _page.Locator("div.recruiting-search__location");

        private ILocator LocationDropdownOptions => _page.Locator(".select2-results");
        //private ILocator LocationElement(string location) => _page.Locator($"//li[contains(text(), '{location}')]");
        private ILocator LocationCityOption(string location) => _page.GetByRole(AriaRole.Option, new() { Name = location });

        private ILocator LocationCountryOption(string city) => LocationCityOption(city).Locator("xpath=ancestor::li[@aria-label]");

     }
}
