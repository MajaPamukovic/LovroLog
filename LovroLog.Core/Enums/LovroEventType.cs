using System.ComponentModel;

namespace LovroLog.Core.Enums
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
