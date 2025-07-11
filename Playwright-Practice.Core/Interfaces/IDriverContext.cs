using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Core.Interfaces
{
    public interface IDriverContext : IAsyncDisposable
    {
            IBrowserContext Context { get;  }

            IPage Page { get; }

            Task NavigateToAsync(string url);            
        
    }
}
