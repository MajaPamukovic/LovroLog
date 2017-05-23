using LovroLog.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.LovroEvents
{
    public class LovroWeighInEvent : LovroBaseEvent
    {
        public LovroWeighInEvent()
            : base()
        {
            Type = LovroEventType.WeighIn;
        }

        public LovroWeighInEvent(double weight, double height = 0, double headCircumference = 0, string note = "")
            : base(LovroEventType.WeighIn, note)
        {
            Weight = weight;
            Height = height;
            HeadCircumference = headCircumference;
        }

        public double Weight { get; set; }
        public double Height { get; set; }
        public double HeadCircumference { get; set; }
    }
}
