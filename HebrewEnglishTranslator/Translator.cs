using System;
using Google.Cloud.Translate.V3;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Poco;

namespace HebrewEnglishTranslator
{
    internal class Translator : ITranslator
    {
        string credPath;
        IDbConnector dbConnector;
        public Translator(string credFilePath, IDbConnector dbConnector)
        {
            credPath = credFilePath;
            this.dbConnector = dbConnector;
        }
        public Name Translate(string textToTranslate, string sourceLanguage = "iw", string targetLanguage = "en")
        {
            var translator = new GoogleTranslator(credPath);
            string googleTranslation = translator.Translate(textToTranslate);
            string phoneticTranslation = PhoneticTranslator.Translate(textToTranslate);

            Name final = TranslationPicker.GetFinalName(textToTranslate, phoneticTranslation, googleTranslation);
            return final;

        }

        private Name[] GetNames(string[] words)
        {
            List<Name> names = new List<Name>();
            foreach (var word in words)
            {
                names.Add(Translate(word));
            }
            return names.ToArray();
        }

        private Name GetDataFromDb(string hebrewText)
        {
            return dbConnector.GetRecord(hebrewText).Result;
        }

        public Name GetFirstName(string hebrewFirstName)
        {
            string lastName = "כהן";
            var res = Translate(hebrewFirstName + " " + lastName);
            return res;
        }

        public Name GetLastName(string HebrewLastName)
        {
            string firstName = "ליאת";
            var res = Translate(firstName + " " + HebrewLastName);
            return res;
        }
    }
}
