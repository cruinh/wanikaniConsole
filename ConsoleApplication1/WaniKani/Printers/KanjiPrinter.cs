using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace WaniKani
{
    public class KanjiPrinter
    {
        public static void print(IEnumerable<Kanji> kanjis)
        {
            foreach (var kanji in kanjis)
            {
                KanjiPrinter.print(kanji);
            }
        }

        public static void print(Kanji kanji)
        {
            Console.Write(" {0}\n", kanji.character);
            Console.Write("   meaning : \"{0}\"\n", kanji.meaning);
            Console.Write("   onyomi : \"{0}\"\n", kanji.onyomi);
            Console.Write("   kunyomi : \"{0}\"\n", kanji.kunyomi);
            Console.Write("   important_reading : \"{0}\"\n", kanji.important_reading);
            Console.Write("   level : {0}\n", kanji.level);
            Console.Write("   nanori : \"{0}\"\n", kanji.nanori);
            ItemUserInfoPrinter.print(kanji.user_specific);
            Console.Write("\n");
        }
    }
}
