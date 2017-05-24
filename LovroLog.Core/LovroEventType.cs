using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Enums
{
    public enum LovroEventType
    {
        [Description("")]
        Default,

        [Description("Srao")]
        Pooped,

        [Description("Jeo")]
        AteFood,

        [Description("Zaspao")]
        FellAsleep,

        [Description("Probudio se")]
        WokeUp,

        [Description("Promijeniše mi pelenu")]
        DiaperChanged,

        [Description("Okupaše me")]
        Bathed,

        [Description("Razno")]
        Other,

        [Description("Mjerenje težine/visine")]
        WeighIn
    }
}
