using LovroLog.Core.Enums;
using System.Runtime.Serialization;

namespace LovroLog.Core.LovroEvents
{
    [DataContract]
    public class LovroDiaperChangedEvent : LovroBaseEvent
    {
        public LovroDiaperChangedEvent()
            : base()
        {
            Type = LovroEventType.DiaperChanged;
        }

        public LovroDiaperChangedEvent(LovroDiaperStatus status, string note = "")
            : base(LovroEventType.DiaperChanged, note)
        {
            Status = status;
        }

        [DataMember]
        public LovroDiaperStatus Status { get; set; }
    }
}
