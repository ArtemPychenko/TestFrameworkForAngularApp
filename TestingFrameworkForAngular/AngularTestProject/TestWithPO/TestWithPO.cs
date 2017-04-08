using AngularTestProject.TestWithPO.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AngularTestProject.TestWithPO
{
    class TestWithPO
    {
        [SetUp]
        public void SetUp()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)))) + @"\TestingFrameworkForAngular\Drivers";
            DriverInitialize.Driver = new ChromeDriver(path);
            DriverInitialize.Driver.Navigate().GoToUrl(@"http://executeautomation.com/demosite/Login.html");
        }

        [Test]
        public void SimpleLoginTestWithPO()
        {
            LoginPage loginPage = new LoginPage();

            MainPage mainPage = loginPage.FillFormFieldsWithCorrectData("test", "test");
            Assert.IsTrue(mainPage.CheckIfMainPageOpened("LOGOUT"));
        }

        [TearDown]
        public void TearDown()
        {
            DriverInitialize.Driver.Close();
        }
    }
}
