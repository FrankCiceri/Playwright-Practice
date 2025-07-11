using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Playwright_Practice.RunSettings
{
    public class RunSettingsHelper
    {
        private readonly XDocument _settings;

        public RunSettingsHelper(string path = "RunSettings.xml")
        {
            _settings = XDocument.Load(path ?? throw new ArgumentNullException(nameof(path)));
        }

        public string GetPlaywrightSetting(string elementName, string defaultValue = null)
        {
            return _settings.Descendants(elementName).FirstOrDefault()?.Value ?? defaultValue;
        }
        
    }
}
