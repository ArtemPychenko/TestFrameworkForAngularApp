using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AngularTestProject
{
    public class SimpleTest
    {
        [Test]
        public void SimpleLoginTest()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)))) + @"\TestingFrameworkForAngular\Drivers";
            IWebDriver driver = new ChromeDriver(path);
            driver.Navigate().GoToUrl(@"http://executeautomation.com/demosite/Login.html");

            driver.FindElement(By.CssSelector("input[name*='UserName']")).SendKeys("test");
            driver.FindElement(By.CssSelector("input[name*='Password']")).SendKeys("test");
            driver.FindElement(By.CssSelector("input[name*='Login']")).Submit();

            Assert.IsTrue(driver.FindElement(By.CssSelector("body>h1")).Text.Contains("Execute Automation Selenium Test Site"));

            driver.Close();
        }
    }
}
