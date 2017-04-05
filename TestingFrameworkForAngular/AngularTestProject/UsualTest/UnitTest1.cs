using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AngularTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory.ToString()))) + @"\TestingFrameworkForAngular\Drivers";
            IWebDriver driver = new ChromeDriver(path);
            driver.Navigate().GoToUrl(@"https://teamtreehouse.com/");
        }
    }
}
