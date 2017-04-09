using Protractor;
using System;

namespace TestingFrameworkForAngular.Base
{
    public class Browser
    {
        private readonly NgWebDriver _ngDriver;

        public Browser(NgWebDriver ngDriver)
        {
            _ngDriver = ngDriver;
        }

        public BrowserType Type { get; set; }

        public void GoToUrl(string url)
        {
            try
            {
                DriverContext.NgDriver.Url = url;
            }
            catch (Exception)
            {
                DriverContext.Driver.Url = url;
            }
            
        }
    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
