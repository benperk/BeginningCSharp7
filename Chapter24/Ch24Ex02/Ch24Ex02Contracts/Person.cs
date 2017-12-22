using System.Runtime.Serialization;

namespace Ch24Ex02Contracts
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Mark { get; set; }
    }
}
