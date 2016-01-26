using LovroLog.LovroEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Database
{
    public interface IDataAccess
    {
        IEnumerable<LovroBaseEvent> GetBaseEvents();
        IEnumerable<LovroDiaperChangedEvent> GetDiaperChangedEvents();
        IEnumerable<DatabaseSummary> GetSummaries();

        LovroBaseEvent AddBaseEvent();
        //int SaveChanges();
    }
}
