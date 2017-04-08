using AngularTestProject.TestWithPO_Specflow.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AngularTestProject.TestWithPO_Specflow.Steps
{
    [Binding]
    class LoginSteps
    {
        LoginPage loginPage = new LoginPage();
        MainPage mainPage = new MainPage();

        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            DriverInitialize.Driver.Navigate().GoToUrl(@"http://executeautomation.com/demosite/Login.html");
        }

        [Given(@"I see login page opened")]
        public void GivenISeeLoginPageOpened()
        {
            loginPage.CheckIfMainPageOpened("LOGIN");
        }

        [When(@"I fill all fields with correct data")]
        public void WhenIFillAllFieldsWithCorrectData(Table table)
        {
            dynamic tableDetail = table.CreateDynamicInstance();
            loginPage.FillFormFieldsWithCorrectData(tableDetail.UserName, tableDetail.Password);
        }

        [When(@"I submit login form")]
        public void WhenISubmitLoginForm()
        {
            mainPage = loginPage.SubmitForm();
        }

        [Then(@"The Main page is opened")]
        public void ThenTheMainPageIsOpened()
        {
            mainPage.CheckIfMainPageOpened("LOGOUT");
        }

    }
}
