using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataSerialization
{
    [DataContract]
    [KnownType(typeof(AppStateData))]
    class AppData
    {
        [DataMember]
        public int TheAnswer { get; set; }
        [DataMember]
        public AppStates State { get; set; }
        [DataMember]
        public object StateData { get; set; }

    }
}
