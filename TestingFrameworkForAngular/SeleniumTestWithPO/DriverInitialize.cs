using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AngularTestProject
{
    public class DriverInitialize
    {
        //Auto-implemented property
        public static IWebDriver Driver { get; set; } 

        public static void InitDriver()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)))) + @"\TestingFrameworkForAngular\Drivers";
            Driver = new ChromeDriver(path);
        }
    }
}
