using LovroLog.Core.Database;
using LovroLog.Core.LovroEvents;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LovroLogService
{
    [ServiceContract]
    public interface ILovroLogService
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

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

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
