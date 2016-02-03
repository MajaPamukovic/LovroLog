using LovroLog.LovroEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Database
{
    public class DataAccessXML : IDataAccess
    {
        public string DataAccessDetails { get; set; }

        public IEnumerable<LovroBaseEvent> GetBaseEvents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LovroDiaperChangedEvent> GetDiaperChangedEvents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DatabaseSummary> GetSummaries()
        {
            throw new NotImplementedException();
        }

        public LovroBaseEvent AddBaseEvent(LovroBaseEvent newEvent)
        {
            throw new NotImplementedException();
        }

        public LovroBaseEvent EditBaseEvent(LovroBaseEvent editedEvent)
        {
            throw new NotImplementedException();
        }

        public void DeleteBaseEvent(int id)
        {
            throw new NotImplementedException();
        }

        public DatabaseSummary GetSummary()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
