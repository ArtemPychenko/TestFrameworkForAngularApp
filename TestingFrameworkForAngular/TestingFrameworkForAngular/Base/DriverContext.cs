using OpenQA.Selenium;
using Protractor;

namespace TestingFrameworkForAngular.Base
{
    public static class DriverContext
    {
        private static IWebDriver _driver;

        private static NgWebDriver _ngDriver;

        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }

        public static NgWebDriver NgDriver
        {
            get
            {
                return _ngDriver;
            }
            set
            {
                _ngDriver = value;
            }
        }

        public static Browser Browser { get; set; }
    }
}
