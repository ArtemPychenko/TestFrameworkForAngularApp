using AngularTestProject.FinalTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestingFrameworkForAngular.Base;

namespace AngularTestProject.FinalTest.Steps
{
    [Binding]
    class CheckLearningAngularPageSteps : BasePage
    {
        [Given(@"I have navigated to the website")]
        public void GivenIHaveNavigatedToTheWebsite()
        {
            CurrentPage = GetInstance<MainPage>();
        }

        [Given(@"I see main page page opened")]
        public void GivenISeeMainPagePageOpened()
        {
            Assert.IsTrue(CurrentPage.As<MainPage>().CheckIfMainPageOpened());
            Assert.IsTrue(CurrentPage.As<MainPage>().GetButtonText().Contains("GET STARTED"));
        }

        [When(@"I click Get started button")]
        public void WhenIClickGetStartedButton()
        {
            CurrentPage = CurrentPage.As<MainPage>().ClickGetStartedButton(); ;
        }

        [Then(@"The quickstartpage opened")]
        public void ThenTheQuickstartpageOpened()
        {
            Assert.IsTrue(CurrentPage.As<QuickstartPage>().CheckIfQuickstartPageOpened());
            Assert.IsTrue(CurrentPage.As<QuickstartPage>().GetHeaderText().Contains("QUICKSTART"));
        }

        [When(@"I click learning angular link")]
        public void WhenIClickLearningAngularLink()
        {
            CurrentPage = CurrentPage.As<QuickstartPage>().ClickLearnAngularLink();
        }

        [Then(@"The learning angular page opened")]
        public void ThenTheLearningAngularPageOpened()
        {
            Assert.IsTrue(CurrentPage.As<LearningAngularPage>().CheckIfLearningAngularPageOpened());
            Assert.IsTrue(CurrentPage.As<LearningAngularPage>().GetLearningAngularHeaderText().Contains("LEARNING ANGULAR"));
        }


    }
}
