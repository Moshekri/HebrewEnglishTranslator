using System;
using Google.Cloud.Translate.V3;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Poco;
using TranslationQualityChecker;

namespace HebrewEnglishTranslator
{
    internal class Translator : ITranslator
    {
        readonly string credPath;
        private readonly TranslationServiceClient translationClient;

        public Translator(string credFilePath)
        {
            credPath = credFilePath;
            TranslationServiceClientBuilder clientBuilder = new TranslationServiceClientBuilder
            {
                CredentialsPath = credPath
            };
            this.translationClient = clientBuilder.Build();
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

        public Name TranslateFirstName(string hebrewFirstName)
        {
            string lastName = "כהן";
            var res = GoogleTranslate(hebrewFirstName + " " + lastName);
            string GoogleHebrewName = GetFirstName(res);
            string phoneticHebrewName = PhoneticTranslator.Translate(hebrewFirstName);
            return TranslationPicker.GetFinalName(hebrewFirstName, phoneticHebrewName, GoogleHebrewName);
        }

        public Name TranslateLastName(string HebrewLastName)
        {
            string firstNmae = "ליאת";
            var res = GoogleTranslate(firstNmae + " " + HebrewLastName);
            string GoogleHebrewName = GetFirstName(res);
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

        private string GoogleTranslate(string textToTranslate, string sourceLanguage = "iw", string targetLanguage = "en")
        {
            TranslateTextRequest req = new TranslateTextRequest()
            {
                Parent = "projects/verdant-current-275412",
                Contents = { textToTranslate },
                SourceLanguageCode = sourceLanguage,
                TargetLanguageCode = targetLanguage,
                Model = "projects/verdant-current-275412/locations/global/models/general/nmt"

            };
            try
            {
                var translationResults = translationClient.TranslateText(req);
                return translationResults.Translations[0].TranslatedText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
