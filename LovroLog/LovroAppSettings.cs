using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog
{
    public class LovroAppSettings
    {
        #region Default settings values
        private static int defaultWarnDiaperUnchangedAfterHrs = 3;
        private static int defaultWarnHasNotBathedAfterDays = 4;
        private static int defaultSilentAlarmBefore = 8;
        private static int defaultSilentAlarmAfter = 20;
        private static bool defaultSilentAlarmAlways = false;
        #endregion

        static LovroAppSettings()
        {
            Instance = new LovroAppSettings();

            Instance.DatabaseConnectionString = ConfigurationManager.AppSettings.Get("DatabaseConnectionString");
            Instance.XMLDatabaseFolder = ConfigurationManager.AppSettings.Get("XMLDatabaseFolder");

            int tempVal; // lošeee
            if (!int.TryParse(ConfigurationManager.AppSettings.Get("AllowedHrsWithoutDiaperChange"), out tempVal))
                Instance.AllowedHrsWithoutDiaperChange = defaultWarnDiaperUnchangedAfterHrs;
            else
                Instance.AllowedHrsWithoutDiaperChange = tempVal;

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("AllowedDaysWithoutBath"), out tempVal))
                Instance.AllowedDaysWithoutBath = defaultWarnHasNotBathedAfterDays;
            else
                Instance.AllowedDaysWithoutBath = tempVal;

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("SilentAlarmBefore"), out tempVal))
                Instance.SilentAlarmBefore = defaultSilentAlarmBefore;
            else
                Instance.SilentAlarmBefore = tempVal;

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("SilentAlarmAfter"), out tempVal))
                Instance.SilentAlarmAfter = defaultSilentAlarmAfter;
            else
                Instance.SilentAlarmAfter = tempVal;

            bool useSilentAlarmAlways;
            if (!bool.TryParse(ConfigurationManager.AppSettings.Get("SilentAlarmAlways"), out useSilentAlarmAlways))
                Instance.SilentAlarmAlways = defaultSilentAlarmAlways;
            else
                Instance.SilentAlarmAlways = useSilentAlarmAlways;
        }

        public int AllowedHrsWithoutDiaperChange { get; set; }
        public int AllowedDaysWithoutBath { get; set; }
        public int SilentAlarmBefore { get; set; }
        public int SilentAlarmAfter { get; set; }
        public bool SilentAlarmAlways { get; set; }
        public string DatabaseConnectionString { get; set; }
        public string XMLDatabaseFolder { get; set; }

        public bool UseXMLDatabase { get { return !string.IsNullOrEmpty(Instance.XMLDatabaseFolder); } }

        public static LovroAppSettings Instance { get; private set; }

        public static int AllowedHrsWithoutDiaperChangeS { get { return Instance == null ? defaultWarnDiaperUnchangedAfterHrs : Instance.AllowedHrsWithoutDiaperChange; } }
        public static int AllowedDaysWithoutBathS { get { return Instance == null ? defaultWarnHasNotBathedAfterDays : Instance.AllowedDaysWithoutBath; } }
        public static int SilentAlarmBeforeS { get { return Instance == null ? defaultSilentAlarmBefore : Instance.SilentAlarmBefore; } }
        public static int SilentAlarmAfterS { get { return Instance == null ? defaultSilentAlarmAfter : Instance.SilentAlarmAfter; } }
        public static bool SilentAlarmAlwaysS { get { return Instance == null ? defaultSilentAlarmAlways : Instance.SilentAlarmAlways; } }
        public static string DatabaseConnectionStringS { get { return Instance == null ? null : Instance.DatabaseConnectionString; } }
        public static string XMLDatabaseFolderS { get { return Instance == null ? null : Instance.XMLDatabaseFolder; } }
    }
}
