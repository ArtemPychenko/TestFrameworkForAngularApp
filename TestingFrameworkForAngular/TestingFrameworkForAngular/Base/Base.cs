using OpenQA.Selenium.Support.PageObjects;
using Protractor;
using TechTalk.SpecFlow;

namespace TestingFrameworkForAngular.Base
{
    public class Base
    {
        public BasePage CurrentPage
        {
            get
            {
                return (BasePage)ScenarioContext.Current["currentPage"];
            }
            set
            {
                ScenarioContext.Current["currentPage"] = value;
            }
        }

        private NgWebDriver _ngDriver { get; set; }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                _ngDriver = DriverContext.NgDriver
            };

            PageFactory.InitElements(DriverContext.NgDriver, pageInstance);
            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
