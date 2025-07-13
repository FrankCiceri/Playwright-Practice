using Microsoft.Playwright;
using Playwright_Practice.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Core.Interfaces
{
    public interface IBrowserFactory
    {
        Task<IBrowserDriver> CreateBrowserAsync();
    }
}
