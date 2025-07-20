using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.Components.JobSearchFilterComponent
{
    public partial class JobSearchFilterComponent
    {
        private ILocator CareerSearchTxtField => Page.Locator("#new_form_job_search-keyword");
        private ILocator CareerSuggestionsMenu => Page.Locator("form#jobSearchFilterForm .autocomplete-suggestions");

        private ILocator RemoteCheckbox => Page.GetByRole(AriaRole.Checkbox, new() { Name = "Remote" });
        private ILocator RemoteCheckContainer => Page.Locator("p").Filter(new LocatorFilterOptions
        {
            Has = RemoteCheckbox
        });

        private ILocator LocationDropdown => Page.Locator("div.recruiting-search__location");
        private ILocator LocationDropdownOptions => Page.Locator(".select2-results");
        //private ILocator LocationElement(string location) => _page.Locator($"//li[contains(text(), '{location}')]");
        private ILocator LocationCityOption(string location) => Page.GetByRole(AriaRole.Option, new() { Name = location });
        private ILocator LocationCountryOption(string city) => LocationCityOption(city).Locator("xpath=ancestor::li[@aria-label]");

        private ILocator JobSearchButton => Page.GetByRole(AriaRole.Button, new() { Name = "Find" });

     }
}
