using LovroLog.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

        public LovroDiaperStatus Status { get; set; }
    }
}
