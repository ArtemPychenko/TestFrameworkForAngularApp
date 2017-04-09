using TestingFrameworkForAngular.Config;
using TestingFrameworkForAngular.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;

namespace TestingFrameworkForAngular.Base
{
    public abstract class TestInitializeHook : Base
    {
        public static void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Set log
            //LogHelpers.CreateLogFile();
        }

        private static void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.NgDriver);
                    break;
                case BrowserType.FireFox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.NgDriver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(
                                                        AppDomain.CurrentDomain.BaseDirectory)))) + @"\TestingFrameworkForAngular\Drivers");
                    DriverContext.NgDriver = new Protractor.NgWebDriver(DriverContext.Driver);
                    DriverContext.Browser = new Browser(DriverContext.NgDriver);
                    break;
            }
        }

        public virtual void NavigateSite()
        {
            //Open Browser
            OpenBrowser(Settings.BrowserType);

            //Set implicit wait
            DriverContext.NgDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);

            DriverContext.Browser.GoToUrl(Settings.AUT);
        }
    }
}
