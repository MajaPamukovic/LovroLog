using LovroLog.Core.LovroEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Core.Database
{
    public interface IDataAccess : IDisposable
    {
        string DataAccessDetails { get; set; } // UNC path of the folder containing XML files or connection string to the database

        IEnumerable<LovroBaseEvent> GetBaseEvents();
        IEnumerable<LovroDiaperChangedEvent> GetDiaperChangedEvents();
        DatabaseSummary GetSummary();

        LovroBaseEvent AddBaseEvent(LovroBaseEvent newEvent);
        LovroBaseEvent EditBaseEvent(LovroBaseEvent editedEvent);
        void DeleteBaseEvent(int id);
    }
}
