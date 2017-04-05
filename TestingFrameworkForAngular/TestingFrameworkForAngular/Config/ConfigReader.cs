using TestingFrameworkForAngular.Base;
using System;
using System.IO;
using System.Xml.XPath;

namespace TestingFrameworkForAngular.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            XPathItem aut;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem buildname;
            XPathItem logpath;
            XPathItem appConnection;
            XPathItem browsertype;

            string strFileName = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(
                                                        AppDomain.CurrentDomain.BaseDirectory)))) + "\\DNAutoFramework\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(strFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML Details and it in XPathItem type variables
            aut = navigator.SelectSingleNode("DNAutoFramework/RunSettings/AUT");
            testtype = navigator.SelectSingleNode("DNAutoFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("DNAutoFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("DNAutoFramework/RunSettings/IsReport");
            buildname = navigator.SelectSingleNode("DNAutoFramework/RunSettings/BuildName");
            logpath = navigator.SelectSingleNode("DNAutoFramework/RunSettings/LogPath");
            appConnection = navigator.SelectSingleNode("DNAutoFramework/RunSettings/DbCredentials");
            browsertype = navigator.SelectSingleNode("DNAutoFramework/RunSettings/Browser");

            //Set XML Details in the property to be used across framework
            Settings.AUT = aut.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReporting = isreport.Value.ToString();
            Settings.BuildName = buildname.Value.ToString();
            Settings.LogPath = logpath.Value.ToString();
            Settings.AppPromoConnectionString = appConnection.Value.ToString();
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), browsertype.Value.ToString());
        }
    }
}
