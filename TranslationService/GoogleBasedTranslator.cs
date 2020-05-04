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
    public class GoogleBasedTranslator : ITranslator
    {
        public Name Translate(string HebrewText)
        {
            IDbConnector connector = DbConnectorFactory.GetDbConnector();
            var translator = HebrewEnglishTranslator.TranslatorFactory.GetTranslator(@"C:\IISSites\TranslationService\Bin\cred.json", connector);
            return translator.Translate(HebrewText);
        }
    }
}
