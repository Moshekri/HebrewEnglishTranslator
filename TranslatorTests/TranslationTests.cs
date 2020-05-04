using System;
using Common.Interfaces;
using Common.Poco;
using DataBaseCon.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TranslatorTests
{
    [TestClass]
    public class TranslationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = HebrewEnglishTranslator.TranslatorFactory.GetTranslator(@"C:\Users\moshe\Source\Repos\HebrewEnglishTranslator\HebrewEnglishTranslator\Cred.json");
            Name res = t.Translate("משה קריכלי");
            Assert.AreEqual(res.English, "Moshe Krichly");
        }
    }
}
