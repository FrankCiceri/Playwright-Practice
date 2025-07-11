

using Microsoft.Playwright;

namespace Playwright_Practice.Business.PageObjects.AboutPage
{
    public partial class AboutPage
    {
        
        public AboutPage(IPage page) 
        { 
            if (_page is null) throw new ArgumentNullException(nameof(page)); 
            _page = page;
        }


    }
}
