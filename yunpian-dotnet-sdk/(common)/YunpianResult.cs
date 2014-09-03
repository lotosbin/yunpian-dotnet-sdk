using System.Runtime.Serialization;

namespace yunpian_dotnet_sdk
{
    [DataContract]
    public class YunpianResult
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Msg { get; set; }
       
    }
}