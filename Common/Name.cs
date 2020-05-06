using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Poco
{
    [DataContract]
    public class Name

    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Hebrew { get; set; }
        [DataMember]
        public string English { get; set; }
        [DataMember]
        public bool IsGoogle { get; set; }
        [DataMember]
        public string DateCreated { get; set; }
        [DataMember]
        public string DateUpdated { get; set; }
    }
}
