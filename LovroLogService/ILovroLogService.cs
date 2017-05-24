using LovroLog.Core.Database;
using LovroLog.Core.LovroEvents;
using System.Collections.Generic;
using System.ServiceModel;

namespace LovroLogService
{
    [ServiceContract]
    public interface ILovroLogService
    {
        [OperationContract]
        IEnumerable<LovroBaseEvent> GetBaseEvents();

        [OperationContract]
        IEnumerable<LovroDiaperChangedEvent> GetDiaperChangedEvents();

        [OperationContract]
        DatabaseSummary GetSummary();

        [OperationContract]
        LovroBaseEvent AddBaseEvent(LovroBaseEvent newEvent);

        [OperationContract]
        LovroBaseEvent EditBaseEvent(LovroBaseEvent editedEvent);

        [OperationContract]
        void DeleteBaseEvent(int id);
    }
}
