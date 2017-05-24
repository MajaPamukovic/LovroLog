using LovroLog.Core.Database;
using LovroLog.Core.LovroEvents;
using System.Collections.Generic;

namespace LovroLogService
{
    public class LovroLogService : ILovroLogService
    {
        public IEnumerable<LovroBaseEvent> GetBaseEvents()
        {
            using (var dataAccess = new DataAccessWrapper(LovroServiceSettings.DataAccessDetails, LovroServiceSettings.UseXMLDatabase))
            {
                return dataAccess.GetBaseEvents();
            }
        }

        public IEnumerable<LovroDiaperChangedEvent> GetDiaperChangedEvents()
        {
            using (var dataAccess = new DataAccessWrapper(LovroServiceSettings.DataAccessDetails, LovroServiceSettings.UseXMLDatabase))
            {
                return dataAccess.GetDiaperChangedEvents();
            }
        }

        public DatabaseSummary GetSummary()
        {
            using (var dataAccess = new DataAccessWrapper(LovroServiceSettings.DataAccessDetails, LovroServiceSettings.UseXMLDatabase))
            {
                return dataAccess.GetSummary();
            }
        }

        public LovroBaseEvent AddBaseEvent(LovroBaseEvent newEvent)
        {
            using (var dataAccess = new DataAccessWrapper(LovroServiceSettings.DataAccessDetails, LovroServiceSettings.UseXMLDatabase))
            {
                return dataAccess.AddBaseEvent(newEvent);
            }
        }

        public LovroBaseEvent EditBaseEvent(LovroBaseEvent editedEvent)
        {
            using (var dataAccess = new DataAccessWrapper(LovroServiceSettings.DataAccessDetails, LovroServiceSettings.UseXMLDatabase))
            {
                return dataAccess.EditBaseEvent(editedEvent);
            }
        }

        public void DeleteBaseEvent(int id)
        {
            using (var dataAccess = new DataAccessWrapper(LovroServiceSettings.DataAccessDetails, LovroServiceSettings.UseXMLDatabase))
            {
                dataAccess.DeleteBaseEvent(id);
            }
        }
    }
}
