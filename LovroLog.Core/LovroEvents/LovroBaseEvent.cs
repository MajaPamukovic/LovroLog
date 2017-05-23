using LovroLog.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Core.LovroEvents
{
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

        public int ID { get; set; }
        public LovroEventType Type { get; set; }
        public DateTime Time { get; set; }
        public string Note { get; set; }

        public void CopyProperties(LovroBaseEvent editedEvent)
        {
            this.Time = editedEvent.Time;
            this.Type = editedEvent.Type;
            this.Note = editedEvent.Note;
        }
    }
}
