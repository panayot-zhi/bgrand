using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGRandomGenerator.Utility
{
    public static class Constants
    {

        public static readonly Dictionary<char, string> TransliterateCyrillic = new Dictionary<char, string>()
        {
            {'А', "A"},
            {'Б', "B"},
            {'В', "V"},
            {'Г', "G"},
            {'Д', "D"},
            {'Е', "E"},
            {'Ж', "ZH"},
            {'З', "Z"},
            {'И', "I"},
            {'Й', "Y"},

            {'К', "K"},
            {'Л', "L"},
            {'М', "M"},
            {'Н', "N"},
            {'О', "O"},
            {'П', "P"},
            {'Р', "R"},
            {'С', "S"},
            {'Т', "T"},
            {'У', "U"},

            {'Ф', "F"},
            {'Х', "H"},
            {'Ц', "TS"},
            {'Ч', "CH"},
            {'Ш', "SH"},
            {'Щ', "SHT"},
            {'Ъ', "A"},
            {'Ь', "Y"},
            {'Ю', "YU"},
            {'Я', "YA"},
        };

        public static string[] CyrillicAlphabet =
        {
            "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф",
            "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ь", "Ю", "Я"
        };

        public static readonly string[] MobileOperators = { "087", "088", "089", "098" };

        public static readonly Dictionary<string, Region> Regions = new Dictionary<string, Region>()
        {
            // Данните са от преброяването на населението през 2011 г.

            { "БЛАГОЕВГРАД", new Region("БЛАГОЕВГРАД", 0, 43)},
            { "БУРГАС", new Region("БУРГАС", 44, 93) },
            { "ВАРНА", new Region("ВАРНА", 94, 139) },
            { "ВЕЛИКО ТЪРНОВО", new Region("ВЕЛИКО ТЪРНОВО", 140, 169) },
            { "ВИДИН", new Region("ВИДИН", 170, 183) },
            { "ВРАЦА", new Region("ВРАЦА", 184, 217) },
            { "ГАБРОВО", new Region("ГАБРОВО", 218, 233) },
            { "ДОБРИЧ", new Region("ДОБРИЧ", 790, 821) },
            { "КЪРДЖАЛИ", new Region("КЪРДЖАЛИ", 234, 281) },
            { "КЮСТЕНДИЛ", new Region("КЮСТЕНДИЛ", 282, 301) },
            { "ЛОВЕЧ", new Region("ЛОВЕЧ", 302, 319) },
            { "МОНТАНА", new Region("МОНТАНА", 320, 341) },
            { "ПАЗАРДЖИК", new Region("ПАЗАРДЖИК", 342, 377) },
            { "ПЕРНИК", new Region("ПЕРНИК", 378, 395) },
            { "ПЛЕВЕН", new Region("ПЛЕВЕН", 396, 435) },
            { "ПЛОВДИВ", new Region("ПЛОВДИВ", 436, 501) },
            { "РАЗГРАД", new Region("РАЗГРАД", 502, 527) },
            { "РУСЕ", new Region("РУСЕ", 528, 555) },
            { "СИЛИСТРА", new Region("СИЛИСТРА", 556, 575) },
            { "СЛИВЕН", new Region("СЛИВЕН", 576, 601) },
            { "СМОЛЯН", new Region("СМОЛЯН", 602, 623) },

            // divided in half
            { "СОФИЯ-град", new Region("СОФИЯ", 624, 721) },
            { "СОФИЯ-окръг", new Region("СОФИЯ", 722, 751) },

            { "СТАРА ЗАГОРА", new Region("СТАРА ЗАГОРА", 752, 789) },
            { "ТЪРГОВИЩЕ", new Region("ТЪРГОВИЩЕ", 822, 843) },
            { "ХАСКОВО", new Region("ХАСКОВО", 844, 871) },
            { "ШУМЕН", new Region("ШУМЕН", 872, 903) },
            { "ЯМБОЛ", new Region("ЯМБОЛ", 904, 925) },

            { "ДРУГ", new Region("ДРУГ", 926, 999) }
        };

        public static readonly int[] EgnWeights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
        public static readonly int[] EnchWeights = { 21, 19, 17, 13, 11, 9, 7, 3, 1 };
        public static readonly int[] LnchWeights = { 21, 19, 17, 13, 11, 9, 7, 3, 1 };
        public static readonly int[] BulstatWeights = { 1, 2, 3, 4, 5, 6, 7, 8, 2, 7, 3, 5 };
        public static readonly int[] BulstatWeights2 = { 3, 4, 5, 6, 7, 8, 9, 10, 4, 9, 5, 7 };

        public static readonly string[] Genders = { "M", "F" }; // TODO: add new genders here when they become popular
    }
}
