using System;
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
            string text = t.Translate("משה קריכלי");
            Assert.AreEqual(text, "Moshe Kricheli");

        }
    }
}
