using System.Runtime.Serialization;
namespace DataSerialization
{
    [DataContract]
    public class AppStateData
    {
        [DataMember]
        public string Data { get; set; }
    }
}
