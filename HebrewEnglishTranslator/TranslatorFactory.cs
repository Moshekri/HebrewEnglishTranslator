using Common.Interfaces;
using DataBaseCon.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HebrewEnglishTranslator
{
    public static class TranslatorFactory
    {
        public static ITranslator GetTranslator(string credFilePath)
        {
            return new Translator(credFilePath);
        }
    }
}
