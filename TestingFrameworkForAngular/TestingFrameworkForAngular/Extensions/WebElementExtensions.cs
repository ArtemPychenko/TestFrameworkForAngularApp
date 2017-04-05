using TestingFrameworkForAngular.Base;
using TestingFrameworkForAngular.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestingFrameworkForAngular.Extensions
{
    public static class WebElementExtensions
    {
        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static string GetText(this IWebElement element)
        {           
            try
            {
                return element.Text;
            }
            catch (Exception e)
            {
                LogHelpers.Write("Element " + element + " not found. Error text: " + e.ToString());
                return "";
            }
        }

        public static void Hover(this IWebElement element)
        {
            Actions action = new Actions(DriverContext.NgDriver);
            action.MoveToElement(element).Perform();
        }

        public static bool AssertElementPresent(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception e)
            {
                LogHelpers.Write("Element " + element + " not found. Error text: " + e.ToString());
                return false;
            }
        }
       
        public static void Clicks(this IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                LogHelpers.Write("Element " + element + " not found. Error text: " + e.ToString());
            }
        }


        //Selecting a drop-down control
        public static void SelectDropDownByIndex(this IWebElement element, int index)
        {
            new SelectElement(element).SelectByIndex(index);
        }

        public static void SelectDropDownByValue(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByValue(value);
        }

        public static void SelectDropDownByText(this IWebElement element, string value)
        { 
            try
            {
                new SelectElement(element).SelectByText(value);
            }
            catch (Exception e)
            {
                LogHelpers.Write("Element " + element + " not found. Error text: " + e.ToString());
            }
        }

        public static string GetTextByValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static void Wait(int timeout)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }
        
        public static string GetTextFromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }

        public static void EnterText(this IWebElement element, string value)
        {
            try
            {
                element.Clear();
                element.SendKeys(value);
            }
            catch (Exception e)
            {
                LogHelpers.Write("Element " + element + " not found. Error text: " + e.ToString());
            }
        }

        public static void DragAndDrop(string source, string destination)
        {
            string text = File.ReadAllText(Path.GetDirectoryName(Path.GetDirectoryName(
                Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)))) + @"\DNAutoFramework\Helpers\DragAndDrop.js");

            string query = text + "$(document.evaluate(\"" + source + "\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue)" +
                ".simulateDragDrop({ dropTarget: document.evaluate(\"" + destination + "\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue });";

            DriverContext.NgDriver.ExecuteJs(query);
        }
    }
}
    