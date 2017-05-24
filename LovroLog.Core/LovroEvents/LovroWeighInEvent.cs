using LovroLog.Core.Enums;
using System.Runtime.Serialization;

namespace LovroLog.Core.LovroEvents
{
    [DataContract]
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

        [DataMember]
        public double Weight { get; set; }

        [DataMember]
        public double Height { get; set; }

        [DataMember]
        public double HeadCircumference { get; set; }
    }
}
