using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestingFrameworkForAngular.Base;
using TestingFrameworkForAngular.Extensions;

namespace AngularTestProject.FinalTest.Pages
{
    class QuickstartPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "header.background-sky>h1")]
        IWebElement QuickstartHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.l-sub-section a[Title*='Learning Angular']")]
        IWebElement LearningAngularLink { get; set; }

        public bool CheckIfQuickstartPageOpened()
        {
            return QuickstartHeader.AssertElementPresent();
        }

        public string GetHeaderText()
        {
            return QuickstartHeader.GetText();
        }

        public LearningAngularPage ClickLearnAngularLink()
        {
            LearningAngularLink.Clicks();
            return GetInstance<LearningAngularPage>();
        }
    }
}
