using TestingFrameworkForAngular.Config;

namespace TestingFrameworkForAngular.Base
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
        }
    }
}
