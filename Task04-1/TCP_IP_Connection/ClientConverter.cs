using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TCP_IP_Connection
{
    public static class ClientConverter
    {
        private static Dictionary<string, string> transliterationTable = new Dictionary<string, string>
        {
            ["а"] = "a",
            ["б"] = "b",
            ["в"] = "v",
            ["г"] = "g",
            ["д"] = "d",
            ["е"] = "e",
            ["ё"] = "yo",
            ["ж"] = "zh",
            ["з"] = "z",
            ["и"] = "i",
            ["й"] = "j",
            ["к"] = "k",
            ["л"] = "l",
            ["м"] = "m",
            ["н"] = "n",
            ["о"] = "o",
            ["п"] = "p",
            ["р"] = "r",
            ["с"] = "s",
            ["т"] = "t",
            ["у"] = "u",
            ["ф"] = "f",
            ["х"] = "x",
            ["ц"] = "c",
            ["ч"] = "ch",
            ["ш"] = "sh",
            ["щ"] = "shh",
            ["ъ"] = "``",
            ["ы"] = "a",
            ["ь"] = "`",
            ["э"] = "e'",
            ["ю"] = "yu",
            ["я"] = "ya"
        };

        public static void ConvertMassage(ref string massage)
        {
            int amountLetters = 0;
            int amountEngLetters = 0;
            foreach (var letter in massage)
            {
                if(char.IsLetter(letter))
                {
                    amountLetters++;
                    if ((int)letter < 123) amountEngLetters++;
                }
            }
            if (amountLetters / 2 < amountEngLetters)
                massage = MassageToEng(massage);
            else
                massage = MassageToRus(massage);
        }

        private static string MassageToRus(string massage)
        {
            foreach (var pattern in transliterationTable)
            {
                Regex.Replace(massage, pattern.Value, pattern.Key);
                Regex.Replace(massage, pattern.Value.ToUpper(), pattern.Key.ToUpper());
            }
            return massage;
        }

        private static string MassageToEng(string massage)
        {
            foreach (var pattern in transliterationTable)
            {
                Regex.Replace(massage, pattern.Key, pattern.Value); 
                Regex.Replace(massage, pattern.Key.ToUpper(), pattern.Value.ToUpper());
            }
            return massage;
        }
    }
}
