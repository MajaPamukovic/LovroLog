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
         private static bool defaultUseXmlDatabase = false;
        #endregion

        private int allowedHrsWithoutDiaperChange;
        private int allowedDaysWithoutBath;
        private int silentAlarmBefore;
        private int silentAlarmAfter;
        private bool silentAlarmAlways;
        private string dataAccessDetails;
        private bool useXMLDatabase;
        
        private static LovroAppSettings instance;

        static LovroAppSettings()
        {
            instance = new LovroAppSettings();

            instance.dataAccessDetails = ConfigurationManager.AppSettings.Get("DataAccessDetails");

            int tempVal; // lošeee
            if (!int.TryParse(ConfigurationManager.AppSettings.Get("AllowedHrsWithoutDiaperChange"), out tempVal))
                instance.allowedHrsWithoutDiaperChange = defaultWarnDiaperUnchangedAfterHrs;
            else
                instance.allowedHrsWithoutDiaperChange = tempVal;

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("AllowedDaysWithoutBath"), out tempVal))
                instance.allowedDaysWithoutBath = defaultWarnHasNotBathedAfterDays;
            else
                instance.allowedDaysWithoutBath = tempVal;

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("SilentAlarmBefore"), out tempVal))
                instance.silentAlarmBefore = defaultSilentAlarmBefore;
            else
                instance.silentAlarmBefore = tempVal;

            if (!int.TryParse(ConfigurationManager.AppSettings.Get("SilentAlarmAfter"), out tempVal))
                instance.silentAlarmAfter = defaultSilentAlarmAfter;
            else
                instance.silentAlarmAfter = tempVal;

            bool tempBoolVal;
            if (!bool.TryParse(ConfigurationManager.AppSettings.Get("SilentAlarmAlways"), out tempBoolVal))
                instance.silentAlarmAlways = defaultSilentAlarmAlways;
            else
                instance.silentAlarmAlways = tempBoolVal;

            if (!bool.TryParse(ConfigurationManager.AppSettings.Get("UseXMLDatabase"), out tempBoolVal))
                instance.useXMLDatabase = defaultUseXmlDatabase;
            else
                instance.useXMLDatabase = tempBoolVal;
        }
        
        public static int AllowedHrsWithoutDiaperChange { get { return instance == null ? defaultWarnDiaperUnchangedAfterHrs : instance.allowedHrsWithoutDiaperChange; } }
        public static int AllowedDaysWithoutBath { get { return instance == null ? defaultWarnHasNotBathedAfterDays : instance.allowedDaysWithoutBath; } }
        public static int SilentAlarmBefore { get { return instance == null ? defaultSilentAlarmBefore : instance.silentAlarmBefore; } }
        public static int SilentAlarmAfter { get { return instance == null ? defaultSilentAlarmAfter : instance.silentAlarmAfter; } }
        public static bool SilentAlarmAlways { get { return instance == null ? defaultSilentAlarmAlways : instance.silentAlarmAlways; } }
        public static string DataAccessDetails { get { return instance == null ? null : instance.dataAccessDetails; } }
        public static bool UseXMLDatabase { get { return instance == null ? defaultUseXmlDatabase : instance.useXMLDatabase; } }
    }
}
