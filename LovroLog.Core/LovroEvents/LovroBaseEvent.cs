using LovroLog.Core.Enums;
using System;
using System.Runtime.Serialization;

namespace LovroLog.Core.LovroEvents
{
    [KnownType(typeof(LovroBaseEvent))]
    [KnownType(typeof(LovroDiaperChangedEvent))]
    [KnownType(typeof(LovroWeighInEvent))]
    [DataContract]
    public class LovroBaseEvent
    {
        public LovroBaseEvent()
        {
            Time = DateTime.Now;
        }

        public LovroBaseEvent(LovroEventType type, string note = "")
            : this()
        {
            Type = type;
            Note = note;
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public LovroEventType Type { get; set; }

        [DataMember]
        public DateTime Time { get; set; }

        [DataMember]
        public string Note { get; set; }

        public void CopyProperties(LovroBaseEvent editedEvent)
        {
            this.Time = editedEvent.Time;
            this.Type = editedEvent.Type;
            this.Note = editedEvent.Note;
        }
    }
}
