using TechTalk.SpecFlow;

namespace AngularTestProject.TestWithPO_Specflow
{
    [Binding]
    public class Hook
    {
        [BeforeTestRun]
        public static void SetUp()
        {
            DriverInitialize.InitDriver();
        }

        [AfterTestRun]
        public static void TearDown()
        {
            DriverInitialize.Driver.Close();
        }
    }
}
