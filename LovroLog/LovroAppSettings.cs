using System.Configuration;

namespace LovroLog
{
    public class LovroAppSettings
    {
        private static LovroAppSettings instance;

        #region Default settings values
        private static int defaultWarnDiaperUnchangedAfterHrs = 3;
        private static int defaultWarnHasNotBathedAfterDays = 4;
        private static int defaultSilentAlarmBefore = 8;
        private static int defaultSilentAlarmAfter = 20;
        private static bool defaultSilentAlarmAlways = false;
        #endregion

        private int allowedHrsWithoutDiaperChange;
        private int allowedDaysWithoutBath;
        private int silentAlarmBefore;
        private int silentAlarmAfter;
        private bool silentAlarmAlways;
        
        static LovroAppSettings()
        {
            instance = new LovroAppSettings();

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
        }
        
        public static int AllowedHrsWithoutDiaperChange { get { return instance == null ? defaultWarnDiaperUnchangedAfterHrs : instance.allowedHrsWithoutDiaperChange; } }
        public static int AllowedDaysWithoutBath { get { return instance == null ? defaultWarnHasNotBathedAfterDays : instance.allowedDaysWithoutBath; } }
        public static int SilentAlarmBefore { get { return instance == null ? defaultSilentAlarmBefore : instance.silentAlarmBefore; } }
        public static int SilentAlarmAfter { get { return instance == null ? defaultSilentAlarmAfter : instance.silentAlarmAfter; } }
        public static bool SilentAlarmAlways { get { return instance == null ? defaultSilentAlarmAlways : instance.silentAlarmAlways; } }
    }
}
