using System;
using Google.Cloud.Translate.V3;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HebrewEnglishTranslator
{
    internal class Translator : ITranslator
    {
        string credFilePath;
        public Translator(string credFileLocation)
        {
            credFilePath = credFileLocation;
        }
        public string Translate(string textToTranslate, string sourceLanguage = "iw", string targetLanguage = "en")
        {
            TranslationServiceClientBuilder clientBuilder = new TranslationServiceClientBuilder();
            clientBuilder.CredentialsPath = credFilePath;
            var translationClient = clientBuilder.Build();
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
