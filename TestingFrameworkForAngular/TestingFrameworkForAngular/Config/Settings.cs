using TestingFrameworkForAngular.Base;
using System.Data.SqlClient;

namespace TestingFrameworkForAngular.Config
{
    public class Settings
    {
        public static string TestType { get; set; }

        public static string AUT { get; set; }

        public static string BuildName { get; set; }

        public static BrowserType BrowserType { get; set; }

        public static SqlConnection ApplicationCon { get; set; }

        public static string AppConnectionString { get; set; }

        public static string IsLog { get; set; }

        public static string LogPath { get; set; }

        public static string IsReporting { get; set; }

        private static bool _fileCreated = false;

        public static bool FileCreated
        {
            get
            {
                return _fileCreated;
            }
            set
            {
                _fileCreated = value;
            }
        }
    }
}
