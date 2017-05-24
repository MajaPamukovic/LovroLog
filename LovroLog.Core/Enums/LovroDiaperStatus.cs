using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Core.Enums
{
    [DataContract]
    public enum LovroDiaperStatus
    {
        [EnumMember]
        [Description("Čista")]
        Clean,

        [EnumMember]
        [Description("Upišana")]
        Pissed,

        [EnumMember]
        [Description("Pokakana")]
        Soiled
    }
}
