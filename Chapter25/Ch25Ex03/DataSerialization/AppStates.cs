using System.Runtime.Serialization;
namespace DataSerialization
{
    [DataContract]
    public enum AppStates
    {
        [EnumMember]
        Started,
        [EnumMember]
        Suspended,
        [EnumMember]
        Closing

    }
}
