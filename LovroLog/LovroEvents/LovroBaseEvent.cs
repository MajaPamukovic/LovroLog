using LovroLog.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.LovroEvents
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
    }
}
