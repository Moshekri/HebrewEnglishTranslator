using System;
using Google.Cloud.Translate.V3;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace HebrewEnglishTranslator
{
    internal class Translator : ITranslator
    {
        string credPath;
        public Translator(string credFilePath)
        {
            credPath = credFilePath;
        }
        public string Translate(string textToTranslate, string sourceLanguage = "iw", string targetLanguage = "en")
        {
            var translator = new GoogleTranslator(credPath);
            string googleTranslation = translator.Translate(textToTranslate);
            string phoneticTranslation = PhoneticTranslator.Translate(textToTranslate);
            string final = TranslationPicker.GetFinalName(textToTranslate, phoneticTranslation, googleTranslation);
            return final;

        }
    }
}
