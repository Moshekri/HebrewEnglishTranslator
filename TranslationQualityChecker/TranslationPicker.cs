using Common.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationQualityChecker
{
    public static class TranslationPicker
    {
        private static double GetGoogleTranslationQuality(string googleTranslation, string phoneticTranslation)
        {
            if (googleTranslation.Length == 0 && phoneticTranslation.Length != 0 || googleTranslation.Length == 0 && phoneticTranslation.Length == 0)
            {
                return 0;
            }


            googleTranslation = googleTranslation.ToLower();
            phoneticTranslation = phoneticTranslation.ToLower();


            double factor = 1;
            double hitCount = 0;

            if (googleTranslation.Length > phoneticTranslation.Length)
            {
                factor = 1.15;
            }
           
            double lettersInGoogleTranslation = googleTranslation.Length;
            foreach (char letter in phoneticTranslation)
            {
                if (letter != '-')
                {
                    if (letter == 'c' || letter == 'C' || letter == 'k' || letter == 'K')
                    {
                        if (googleTranslation.Contains("k") || googleTranslation.Contains("K") || googleTranslation.Contains("c") || googleTranslation.Contains("C"))
                        {
                            hitCount++;
                        }

                    }
                    else if (googleTranslation.Contains(letter.ToString()))
                    {
                        hitCount += (1 * factor);
                    }
                }
            }
            if (googleTranslation.Length > phoneticTranslation.Length)
            {
                return ((hitCount * 100) / lettersInGoogleTranslation) * factor;
            }
            else
            {
                return ((hitCount * 100) / phoneticTranslation.Length) * factor;
            }

        }

        public static Name GetFinalName(string hebrew, string phonetic, string google)
        {

            double googleTranslationQuality = GetGoogleTranslationQuality(google, phonetic);
            var q1 = LevenshteinDistance.Compute(google, phonetic);

            if (googleTranslationQuality < 50 || (google.Length > 8 ? q1 >= 6 : q1 > 4))
            {
                return new Name()
                {
                    DateCreated = DateTime.Now.ToString(),
                    English = phonetic,
                    Hebrew = hebrew,
                    IsGoogle = false
                };
            }
            else
            {
                return new Name()
                {
                    DateCreated = DateTime.Now.ToString(),
                    English = google,
                    Hebrew = hebrew,
                    IsGoogle = true
                };
            }

        }
    }
}
