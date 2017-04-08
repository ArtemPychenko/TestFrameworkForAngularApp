using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AngularTestProject.TestWithPO_Specflow.Pages
{
    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(DriverInitialize.Driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[name*='UserName']")]
        IWebElement UserNameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name*='Password']")]
        IWebElement PasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[name*='Login']")]
        IWebElement BtnSubmit { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cssmenu:first-child a>span")]
        IWebElement BtnLogin { get; set; }

        public string GetBtnLoginName()
        {
            return BtnLogin.Text;
        }

        public bool CheckIfMainPageOpened(string compareText)
        {
            return GetBtnLoginName().Contains(compareText);
        }

        public void FillFormFieldsWithCorrectData(string userName, string password)
        {
            UserNameField.SendKeys(userName);
            PasswordField.SendKeys(password);
        }

        public MainPage SubmitForm()
        {
            BtnSubmit.Submit();
            return new MainPage();
        }
    }
}
