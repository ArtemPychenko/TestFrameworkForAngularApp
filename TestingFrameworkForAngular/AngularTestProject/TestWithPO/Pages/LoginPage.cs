using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AngularTestProject.TestWithPO.Pages
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
        IWebElement BtnLogin { get; set; }

        public MainPage FillFormFieldsWithCorrectData(string userName, string password)
        {
            UserNameField.SendKeys(userName);
            PasswordField.SendKeys(password);
            BtnLogin.Submit();
            return new MainPage();
        }
    }
}
