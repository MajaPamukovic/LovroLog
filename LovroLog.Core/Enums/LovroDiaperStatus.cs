using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Core.Enums
{
    public enum LovroDiaperStatus
    {
        [Description("Čista")]
        Clean,

        [Description("Upišana")]
        Pissed,

        [Description("Pokakana")]
        Soiled
    }
}
