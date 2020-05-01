using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ITranslator
    {
        string Translate(string textToTranslate, string sourceLanguage = "iw", string targetLanguage = "en");
    }
}
