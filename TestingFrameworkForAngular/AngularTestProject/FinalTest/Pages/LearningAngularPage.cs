using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestingFrameworkForAngular.Base;
using TestingFrameworkForAngular.Extensions;

namespace AngularTestProject.FinalTest.Pages
{
    class LearningAngularPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "h1.hero-title")]
        IWebElement LearningAngularHeader { get; set; }

        public bool CheckIfLearningAngularPageOpened()
        {
            return LearningAngularHeader.AssertElementPresent();
        }

        public string GetLearningAngularHeaderText()
        {
            return LearningAngularHeader.GetText();
        }
    }
}
