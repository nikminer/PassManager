using System.Runtime.Serialization;
namespace PassManager
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string hash { get; set; }

        public Account(string name, string password, string hash)
        {
            this.name = name;
            this.password = password;
            this.hash = hash;
        }
    }
}
