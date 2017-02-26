using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace WaniKani
{
    public class KanjiPrinter
    {
        public static void printFailure(KanjiResponse kanjiResponse)
        {
            HttpResponseMessage httpResponse = kanjiResponse.httpResponse;
            Console.WriteLine("{0} ({1})", (int)httpResponse.StatusCode, httpResponse.ReasonPhrase);
        }

        public static void print(KanjiResponse kanjiResponse)
        {
            if (kanjiResponse.user_information != null && kanjiResponse.requested_information != null)
            {
                //Console.WriteLine(kanjiResponse.httpResponse.ToString());

                //string strResponse = kanjiResponse.httpResponse.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(strResponse);

                UserInfoPrinter.print(kanjiResponse.user_information);
                KanjiPrinter.print(kanjiResponse.requested_information);
            }
            else
            {
                Console.WriteLine(kanjiResponse.httpResponse.ToString());
            }
        }

        public static void print(IEnumerable<Kanji> kanjis)
        {
            foreach (var kanji in kanjis)
            {
                Console.Write("\t");
                KanjiPrinter.print(kanji);
            }
        }

        public static void print(Kanji kanji)
        {
            Console.Write("{0}\n", kanji.character);
            Console.Write("\t\tmeaning : \"{0}\"\n", kanji.meaning);
            Console.Write("\t\tonyomi : \"{0}\"\n", kanji.onyomi);
            Console.Write("\t\tkunyomi : \"{0}\"\n", kanji.kunyomi);
            Console.Write("\t\timportant_reading : \"{0}\"\n", kanji.important_reading);
            Console.Write("\t\tlevel : {0}\n", kanji.level);
            Console.Write("\t\tnanori : \"{0}\"\n", kanji.nanori);
            Console.Write("\n");
        }
    }
}
