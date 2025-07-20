using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Practice.Core.Utils.ArgumentValidator
{
    public static class ArgumentValidator
    {
        public static void CheckArgumentIsNull<T>(T argument, string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName, $"{argumentName} Can't Be Null");
            }
        }
    }
}
