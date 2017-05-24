using System.Configuration;

namespace LovroLogService
{
    public class LovroServiceSettings
    {
        private static LovroServiceSettings instance;
        private static bool defaultUseXmlDatabase = false;

        private string dataAccessDetails;
        private bool useXMLDatabase;

        static LovroServiceSettings()
        {
            instance = new LovroServiceSettings();

            instance.dataAccessDetails = ConfigurationManager.AppSettings.Get("DataAccessDetails");

            bool tempBoolVal;
            if (!bool.TryParse(ConfigurationManager.AppSettings.Get("UseXMLDatabase"), out tempBoolVal))
                instance.useXMLDatabase = defaultUseXmlDatabase;
            else
                instance.useXMLDatabase = tempBoolVal;
        }

        public static string DataAccessDetails { get { return instance == null ? null : instance.dataAccessDetails; } }

        public static bool UseXMLDatabase { get { return instance == null ? defaultUseXmlDatabase : instance.useXMLDatabase; } }
    }
}