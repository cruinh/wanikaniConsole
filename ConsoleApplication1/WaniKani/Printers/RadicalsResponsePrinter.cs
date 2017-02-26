using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    class RadicalsResponsePrinter
    {
        public static void printFailure(RadicalsResponse radicalsResponse)
        {
            HttpResponseMessage httpResponse = radicalsResponse.httpResponse;
            Console.WriteLine("{0} ({1})", (int)httpResponse.StatusCode, httpResponse.ReasonPhrase);
        }

        public static void print(RadicalsResponse radicalsResponse)
        {
            if (radicalsResponse.user_information != null && radicalsResponse.requested_information != null)
            {
                UserInfoPrinter.print(radicalsResponse.user_information);
                RadicalsPrinter.print(radicalsResponse.requested_information);
            }
            else
            {
                Console.WriteLine(radicalsResponse.httpResponse.ToString());
            }
        }
    }
}
