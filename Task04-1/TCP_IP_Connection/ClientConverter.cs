using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TCP_IP_Connection
{
    public static class ClientConverter
    {
        private static Dictionary<string, string> transliterationTable = new Dictionary<string, string>
        {
            ["щ"] = "shh",
            ["ч"] = "ch",
            ["ш"] = "sh",
            ["ю"] = "yu",
            ["я"] = "ya",
            ["ё"] = "yo",
            ["ж"] = "zh",
            ["а"] = "a",
            ["б"] = "b",
            ["в"] = "v",
            ["г"] = "g",
            ["д"] = "d",
            ["е"] = "e",
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
            ["ъ"] = "``",
            ["ы"] = "a",
            ["ь"] = "`",
            ["э"] = "e'"
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
                massage = MassageToRus(massage);
            else
                massage = MassageToEng(massage);
        }

        private static string MassageToRus(string massage)
        {
            foreach (var pattern in transliterationTable)
            {
                massage = Regex.Replace(massage, pattern.Value, pattern.Key);
                massage = Regex.Replace(massage, pattern.Value.ToUpper(), pattern.Key.ToUpper());
            }
            return massage;
        }

        private static string MassageToEng(string massage)
        {
            foreach (var pattern in transliterationTable)
            {
                massage = Regex.Replace(massage, pattern.Key, pattern.Value);
                massage = Regex.Replace(massage, pattern.Key.ToUpper(), pattern.Value.ToUpper());
            }
            return massage;
        }
    }
}
