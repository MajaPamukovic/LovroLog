using LovroLog.LovroEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Database
{
    public class DataAccessWrapper : IDataAccess
    {
        private bool useXMLDatabase = false;
        private LovroContext databaseAccessor;

        public DataAccessWrapper(string dataAccessDetails, bool useXMLDatabase)
        {
            this.DataAccessDetails = dataAccessDetails;
            this.useXMLDatabase = useXMLDatabase;

            if (useXMLDatabase)
                throw new NotImplementedException();

            this.databaseAccessor = new LovroContext(DataAccessDetails);
        }

        public string DataAccessDetails { get; set; }

        public DatabaseSummary GetSummary()
        {
            if (useXMLDatabase)
                throw new NotImplementedException();

            return databaseAccessor.Summaries.FirstOrDefault();
        }

        public IEnumerable<LovroBaseEvent> GetBaseEvents()
        {
            if (useXMLDatabase)
                throw new NotImplementedException();

            return databaseAccessor.BaseEvents;
        }

        public IEnumerable<LovroDiaperChangedEvent> GetDiaperChangedEvents()
        {
            if (useXMLDatabase)
                throw new NotImplementedException();

            return databaseAccessor.DiaperChangedEvents;
        }

        public DatabaseSummary GetDatabaseSummary()
        { 
            if (useXMLDatabase)
                throw new NotImplementedException();
            
            return databaseAccessor.Summaries.FirstOrDefault();
        }

        public void DeleteBaseEvent(int id)
        {
            if (useXMLDatabase)
                throw new NotImplementedException();

            LovroBaseEvent eventToDelete = databaseAccessor.BaseEvents.FirstOrDefault(item => item.ID == id);
            if (eventToDelete != null)
            {
                databaseAccessor.BaseEvents.Remove(eventToDelete);
            }
        }

        public LovroBaseEvent AddBaseEvent(LovroBaseEvent newEvent)
        {
            if (useXMLDatabase)
                throw new NotImplementedException();
            
            if (newEvent != null)
            {
                newEvent = databaseAccessor.BaseEvents.Add(newEvent);
                return newEvent; // now with ID set automatically by the database
            }
            
            return null;
        }

        public LovroBaseEvent EditBaseEvent(LovroBaseEvent editedEvent)
        {
            if (useXMLDatabase)
                throw new NotImplementedException();

            if (editedEvent != null)
            {
                LovroBaseEvent savedEvent = databaseAccessor.BaseEvents.FirstOrDefault(item => item.ID == editedEvent.ID);
                if (savedEvent != null)
                    savedEvent.CopyProperties(editedEvent);

                return savedEvent;
            }

            return null;
        }

        public void Dispose()
        {
            if (this.databaseAccessor != null)
            {
                databaseAccessor.SaveChanges();
                this.databaseAccessor.Dispose();
            }
        }
    }
}
