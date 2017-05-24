using System.ComponentModel;
using System.Runtime.Serialization;

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
