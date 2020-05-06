using Common.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ITranslator
    {
        Name Translate(string textToTranslate, string sourceLanguage = "iw", string targetLanguage = "en");
        Name TranslateFirstName(string hebrewFirstName);
        Name TranslateLastName(string HebrewLastName);

    }
}
