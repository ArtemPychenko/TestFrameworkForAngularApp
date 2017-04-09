using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestingFrameworkForAngular.Base;
using TestingFrameworkForAngular.Extensions;

namespace AngularTestProject.FinalTest.Pages
{
    class MainPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "a.hero-cta.button")]
        IWebElement GetStartedButton { get; set; }
        
        public bool CheckIfMainPageOpened()
        {
            return GetStartedButton.AssertElementPresent();
        }

        public string GetButtonText()
        {
            return GetStartedButton.GetText();
        }

        public QuickstartPage ClickGetStartedButton()
        {
            GetStartedButton.Clicks();
            return GetInstance<QuickstartPage>();
        }
    }
}
