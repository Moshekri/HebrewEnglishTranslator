using Common.Interfaces;
using Common.Poco;
using DataBaseCon.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TranslationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GoogleBasedTranslator : ITranslatorService
    {
        public Name Translate(string HebrewText)
        {
            IDbConnector connector = DbConnectorFactory.GetDbConnector();
            //TODO: get the cred location from settings
            var translator = HebrewEnglishTranslator.TranslatorFactory.GetTranslator(@"C:\IISSites\TranslationService\Bin\cred.json", connector);

            string firstName = GetFirstName(HebrewText);
            string LastName = GetLastName(HebrewText);

            Name translatedFirstName = translator.TranslateFirstName(firstName);
            Name translatedLastName = translator.TranslateLastName(LastName);
            Name Final = new Name() 
            {
                DateCreated = DateTime.Now.ToString(),
                DateUpdated = DateTime.Now.ToString(),
                English = translatedFirstName.English + " " + translatedLastName.English,
                Hebrew = translatedFirstName.Hebrew + " "+translatedLastName.Hebrew,
                IsGoogle = translatedFirstName.IsGoogle && translatedLastName.IsGoogle
            };

            return Final;
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
