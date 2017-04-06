using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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

            driver.FindElement(By.CssSelector("a[data-analytics-link*='Sign In']")).Click();

            WebDriverWait waitLogin = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement elementLogin = waitLogin.Until(ExpectedConditions.ElementIsVisible(By.Id("user_session_email")));
            driver.FindElement(By.Id("user_session_email")).SendKeys("test@test.test");

            WebDriverWait waitPass = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement elementPass = waitPass.Until(ExpectedConditions.ElementIsVisible(By.Id("user_session_password")));
            driver.FindElement(By.Id("user_session_password")).SendKeys("test");

            driver.FindElement(By.CssSelector("form[id*='new_user_session']>button[type*='submit']")).Click();

            string errorMessage = driver.FindElement(By.CssSelector("p[class*='error-message']")).Text;

            Assert.IsTrue(errorMessage.Contains("This account is cancelled."));

            driver.Quit();
        }
    }
}
