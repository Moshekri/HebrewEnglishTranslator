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
            TS2.TranslatorClient c = new TS2.TranslatorClient();
            Console.WriteLine(c.Translate("חיים קריכלי").English);
        }
    }
}
