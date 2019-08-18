using System.Runtime.Serialization;
namespace PassManager
{
    [DataContract]
    public class AccountDataContract
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string hash { get; set; }

        public AccountDataContract(string name, string password, string hash)
        {
            this.name = name;
            this.password = password;
            this.hash = hash;
        }
    }
}
