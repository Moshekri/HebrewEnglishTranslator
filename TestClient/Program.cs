using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Sr2.TranslatorClient c = new Sr2.TranslatorClient();
            Console.WriteLine(c.Translate("משה קריכלי").English);
        }
    }
}
