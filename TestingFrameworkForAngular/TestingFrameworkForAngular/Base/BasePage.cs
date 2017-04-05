using OpenQA.Selenium.Support.PageObjects;

namespace TestingFrameworkForAngular.Base
{
    public abstract class BasePage : Base
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.NgDriver, this);
        }
    }
}
