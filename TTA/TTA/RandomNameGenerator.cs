using System;
using System.Collections.Generic;
using System.Text;

namespace TTA
{
    public static class RandomNameGenerator
    {
        private static List<string> names = new List<string> {
            "Frank",
            "Woofer",
            "Annie",
            "L33t",
            "<(^.^)>",
            "Jerry",
            "Max",
            "Samurai",
            "Chloe",
            "Dory",
        };

        public static string getRandomName()
        {
            Random rng = new Random();
            return names[rng.Next(names.Count)];
        }

        public static List<string> getRandomNames(int number)
        {
            if (number < names.Count)
                return names.GetRange(0, number);
            else
                return null;
        }
    }
}
