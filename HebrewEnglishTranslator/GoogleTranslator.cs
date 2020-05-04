using Common.Interfaces;
using Google.Cloud.Translate.V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HebrewEnglishTranslator
{
    internal class GoogleTranslator
    {
        string credFilePath;
        internal GoogleTranslator(string CredFilePath)
        {
            this.credFilePath = CredFilePath;
        }
        private string GoogleTranslate(string textToTranslate, string sourceLanguage = "iw", string targetLanguage = "en")
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

        internal string Translate(string textToTranslate, string sourceLanguage = "iw", string targetLanguage = "en")
        {
            return GoogleTranslate(textToTranslate, sourceLanguage, targetLanguage);
        }
    }
}
