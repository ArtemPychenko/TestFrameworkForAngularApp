using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AngularTestProject.TestWithPO_Specflow.Pages
{
    public class MainPage
    {
        public MainPage()
        {
            PageFactory.InitElements(DriverInitialize.Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#cssmenu:first-child a>span")]
        IWebElement BtnLogout { get; set; }

        public string GetBtnLogoutName()
        {
            return BtnLogout.Text;
        }

        public bool CheckIfMainPageOpened(string compareText)
        {
            return GetBtnLogoutName().Contains(compareText);
        }
    }
}
