using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Core.Interfaces
{
    public interface ISearchable
    {
        Task SearchJobs(string keyword, string location, bool isRemote);
    }
}
