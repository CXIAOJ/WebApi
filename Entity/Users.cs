using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [DataContract] //数据契约  可被序列化在客户端和服务端之间
    public class Users
    {
        [DataMember]//可被序列化的成员 必须有GET和SET访问器
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}
