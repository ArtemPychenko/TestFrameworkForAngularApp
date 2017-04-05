using Protractor;

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
            DriverContext.NgDriver.Url = url;
        }
    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
