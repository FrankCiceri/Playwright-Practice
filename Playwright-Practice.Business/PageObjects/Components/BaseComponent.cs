using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Business.PageObjects.Components
{
    public abstract class BaseComponent
    {
        protected readonly IPage Page;

        protected BaseComponent(IPage page)
        {
            Page = page ?? throw new ArgumentNullException(nameof(page));
        }

    }
}
