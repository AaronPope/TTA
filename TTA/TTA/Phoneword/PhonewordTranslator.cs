using System;
using System.Collections.Generic;
using System.Text;

namespace Phoneword.Core
{
    public static class PhonewordTranslator
    {
        private const string NUM_PAD_CHARS = "-0123456789";

        public static string ToNumber(string raw)
        {
            if (string.IsNullOrEmpty(raw)) {
                return null;
            }

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();

            foreach (char c in raw) {
                if (NUM_PAD_CHARS.Contains(c)) {
                    newNumber.Append(c);
                }
                else {
                    var translatedChar = TranslateToNumber(c);
                    
                    if (translatedChar == null) {
                        return null;
                    }

                    newNumber.Append(translatedChar.ToString() ?? "");
                }
            }

            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        static readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++) {
                if (digits[i].Contains(c)) {
                    return 2 + i;
                }
            }

            return null;
        }
    }
}
