using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    class KanjiResponsePrinter
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
                UserInfoPrinter.print(kanjiResponse.user_information);
                KanjiPrinter.print(kanjiResponse.requested_information);
            }
            else
            {
                Console.WriteLine(kanjiResponse.httpResponse.ToString());
            }
        }
    }
}
