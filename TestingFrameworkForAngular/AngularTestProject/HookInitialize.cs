//using DNAutoFramework.Base;
//using DNAutoFramework.Config;
//using DNAutoFramework.Helpers;
//using TechTalk.SpecFlow;
//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
//using AventStack.ExtentReports.Reporter.Configuration;
//using AventStack.ExtentReports.Gherkin.Model;
//using System;
//using System.Drawing.Imaging;
//using System.IO;
//using OpenQA.Selenium;

//namespace EAEmployeeTest
//{
//    [Binding]
//    public class HookInitialize : TestInitializeHook
//    {
//        private static ExtentReports extent;
//        private static ExtentHtmlReporter htmlReporter;
//        private static ExtentTest test;
//        private static ExtentTest scenario;
//        private static String reportPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(
//                                                        AppDomain.CurrentDomain.BaseDirectory)))) + "\\EAEmployeeTest\\Reports\\";

//        private int _screenshotCount;


//        [BeforeTestRun]
//        public static void StartReport()
//        {
//            htmlReporter = new ExtentHtmlReporter(reportPath + "Report.html");
//            extent = new ExtentReports();
//            extent.AttachReporter(htmlReporter);
//            extent.AddSystemInfo("Environment", "QA");
//            extent.AddSystemInfo("User Name", "Artem");
//            extent.AddSystemInfo("System", "Windows 10");

//            // chart location (top, bottom)
//            htmlReporter.Configuration().ChartLocation = ChartLocation.Top;

//            // show chart on report open
//            htmlReporter.Configuration().ChartVisibilityOnOpen = true;

//            // set theme
//            htmlReporter.Configuration().Theme = Theme.Dark;

//            // protocol for resources (http, https)
//            htmlReporter.Configuration().Protocol = Protocol.HTTPS;

//            htmlReporter.Configuration().ReportName = "Test report - QA";
//            htmlReporter.Configuration().DocumentTitle = "Test results";
//            htmlReporter.Configuration().Encoding = "utf-8";
//        }

//        [BeforeFeature]
//        public static void TestStart()
//        {
//            InitializeSettings();
//            Settings.ApplicationPromoCon = Settings.ApplicationPromoCon.DBConnect(Settings.AppPromoConnectionString);
//            Settings.ApplicationLoyaltyCon = Settings.ApplicationLoyaltyCon.DBConnect(Settings.AppLoyaltyConnectionString);
//            Settings.ApplicationTargetCon =  Settings.ApplicationTargetCon.DBConnect(Settings.AppTargetConnectionString);
//            test = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
//        }

//        [BeforeScenario]
//        public void ScenarioInfo()
//        {
//            NavigateSite();           
//            scenario = test.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
//        }

//        [AfterStep]
//        public void AfterTestStep()
//        {
//            string stepType = ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType.ToString();
//            var error = ScenarioContext.Current.TestError;
//            string stepInfo = ScenarioContext.Current.StepContext.StepInfo.Text;

//            if (stepType == "Given" && error != null)

//                scenario.CreateNode<Given>(stepInfo).Fail(error.Message);

//            else if (stepType == "Given" && error == null)

//                scenario.CreateNode<Given>(stepInfo).Pass("step passed");

//            if (stepType == "When" && error != null)

//                scenario.CreateNode<When>(stepInfo).Fail(error.Message);

//            else if (stepType == "When" && error == null)

//                scenario.CreateNode<When>(stepInfo).Pass("step passed");

//            if (stepType == "Then" && error != null)
//            {

//                var screenShootName = ScenarioContext.Current.ScenarioInfo.Title.Replace(" ", "").ToLower();
//                takeScreenShot(screenShootName);

//                scenario.CreateNode<Then>(stepInfo).Fail(error.Message);
//                extent.AddTestRunnerLogs(ScenarioContext.Current.ScenarioInfo.Title);
//                extent.AddTestRunnerLogs($"<pre><h6>Step info: </h6>{stepInfo}</pre>");
//                extent.AddTestRunnerLogs($"<pre><h6>Error description: </h6>{error.Message}</pre>");
                
//                extent.AddTestRunnerLogs($"<pre><h6>Error message: </h6>{error}");
//                extent.AddTestRunnerLogs($"<img src=\""+ screenShootName + ".png\"></pre>");

//            }
//            else if (stepType == "Then" && error == null)

//                scenario.CreateNode<Then>(stepInfo).Pass("step passed");

//            if (stepType == "And" && error != null)

//                scenario.CreateNode<And>(stepInfo).Fail(error.Message);

//            else if (stepType == "And" && error == null)

//                scenario.CreateNode<And>(stepInfo).Pass("step passed");
//        }

//        public void takeScreenShot(String fileName)
//        {
//            string currentDate = DateTime.Now.ToString("ddd, ddMMMyyyy HHmm");
//            ITakesScreenshot screenshotHandler = DriverContext.Driver as ITakesScreenshot;
//            Screenshot screenshot = screenshotHandler.GetScreenshot();
//            screenshot.SaveAsFile(reportPath + fileName + ".png", ImageFormat.Png);
//        }


//        [AfterScenario]
//        public void TestStop()
//        {
//            DriverContext.Driver.Quit();           
//        }

//        [AfterTestRun]
//        public static void End()
//        {
//            extent.Flush();
//        }


//    }
//}
