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
           Name translatedFirstName = TranslateFirstName(GetFirstName(textToTranslate));
           Name translatedLastName = TranslateLastName(GetLastName(textToTranslate));
            return new Name()
            {
                DateCreated = DateTime.Now.ToString(),
                DateUpdated = DateTime.Now.ToString(),
                English = translatedFirstName.English + " " + translatedLastName.English,
                Hebrew = translatedFirstName.Hebrew + " " + translatedLastName.Hebrew,
                IsGoogle = translatedLastName.IsGoogle && translatedFirstName.IsGoogle
            };
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

        public Name TranslateFirstName(string hebrewFirstName)
        {
            string lastName = "כהן";
            var res = TranslateFirstName(hebrewFirstName + " " + lastName);
            string GoogleHebrewName = GetFirstName(res.Hebrew);
            string phoneticHebrewName = PhoneticTranslator.Translate(hebrewFirstName);
            return TranslationPicker.GetFinalName(hebrewFirstName,phoneticHebrewName,GoogleHebrewName);
        }

        public Name TranslateLastName(string HebrewLastName)
        {
            string firstNmae = "ליאת";
            var res = TranslateFirstName(firstNmae + " " + HebrewLastName);
            string GoogleHebrewName = GetFirstName(res.Hebrew);
            string phoneticHebrewName = PhoneticTranslator.Translate(HebrewLastName);
            return TranslationPicker.GetFinalName(HebrewLastName, phoneticHebrewName, GoogleHebrewName);
        }

        private string GetLastName(string hebrewText)
        {
            string temp = string.Empty;
            bool pastFirstName = false;
            foreach (char c in hebrewText)
            {
                if (c == ' ')
                {
                    pastFirstName = true;
                }
                else if (pastFirstName)
                {
                    temp += c;
                }
            }
            return temp;
        }

        private string GetFirstName(string hebrewText)
        {
            string temp = string.Empty;
            foreach (char c in hebrewText)
            {
                if (c != ' ')
                {
                    temp += c;
                }
                else
                {
                    break;
                }
            }
            return temp;
        }

        
    }
}
