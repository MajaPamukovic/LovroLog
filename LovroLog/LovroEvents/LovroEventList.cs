using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LovroLog.LovroEvents
{
    [XmlInclude(typeof(LovroBaseEvent)), XmlInclude(typeof(LovroDiaperChangedEvent)), XmlInclude(typeof(LovroWeighInEvent))]
    [XmlRoot("Events")]
    public class LovroEventList : List<LovroBaseEvent>
    {
        public LovroEventList() : base() { }
    }
}
