using TestingFrameworkForAngular.Base;
using OpenQA.Selenium;
using Protractor;
using System;
using System.Diagnostics;

namespace TestingFrameworkForAngular.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeout)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };
            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeout)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        public static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.NgDriver).ExecuteScript(script);
        }

        public static void RefreshPage(this NgWebDriver driver)
        {
            driver.Navigate().Refresh();
        }
    }
}
