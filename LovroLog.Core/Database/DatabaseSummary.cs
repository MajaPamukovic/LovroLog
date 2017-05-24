using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LovroLog.Core.Database
{
    [DataContract]
    public class DatabaseSummary
    {
        [DataMember]
        public DateTime LastModified { get; set; }

        [DataMember]
        public int ID { get; set; }
    }
}
