using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Playwright_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.Components.HeaderComponent
{
    public partial class HeaderComponent : BaseComponent, IHeaderComponent
    {
        public HeaderComponent(IPage page) : base(page)
        { 
        }


        public async Task NavigateToJoinOurTeamPage()
        {
            await HoverCareersLink();  
            await ClickJoinOurTeamButton();
        }

        public async Task NavigateToCareersPage()
        {
            await ClickCareersLink();
        }


    }
}
