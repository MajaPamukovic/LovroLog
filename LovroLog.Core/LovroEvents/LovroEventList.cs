using System.Collections.Generic;
using System.Xml.Serialization;

namespace LovroLog.Core.LovroEvents
{
    [XmlInclude(typeof(LovroBaseEvent)), XmlInclude(typeof(LovroDiaperChangedEvent)), XmlInclude(typeof(LovroWeighInEvent))]
    [XmlRoot("Events")]
    public class LovroEventList : List<LovroBaseEvent>
    {
        public LovroEventList() : base() { }
    }
}
