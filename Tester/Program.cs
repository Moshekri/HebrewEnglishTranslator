using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HebrewEnglishTranslator;
    

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var translator = TranslatorFactory.GetTranslator("cred.json");
            Console.WriteLine(translator.Translate("חיים סלמה"));
        }
    }
}
