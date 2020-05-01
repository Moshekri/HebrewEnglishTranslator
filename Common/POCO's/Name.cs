using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Poco
{
    public class Name

    {
        public int Id { get; set; }
        public string Hebrew { get; set; }
        public string English { get; set; }
        public bool IsGoogle { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
    }
}
