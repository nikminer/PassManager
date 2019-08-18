using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
namespace PassManager
{
    class Json
    {
        public static object load(Type sender,Stream stream)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(sender);
            return jsonSerializer.ReadObject(stream);
        }
        public static void dump(Type sender, string file, object obj)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(sender);
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                jsonSerializer.WriteObject(fs, obj);
            }
        }
    }
}
