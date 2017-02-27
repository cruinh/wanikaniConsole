using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    public class UserInfoReponsePrinter
    {
        public static void printFailure(UserInfoResponse userInfoResponse)
        {
            HttpResponseMessage httpResponse = userInfoResponse.httpResponse;
            Console.WriteLine("{0} ({1})", (int)httpResponse.StatusCode, httpResponse.ReasonPhrase);
        }

        public static void print(UserInfoResponse userInfoResponse)
        {
            if (userInfoResponse.success())
            {
                UserInfoPrinter.print(userInfoResponse.user_information);
            }
            else
            {
                Console.WriteLine(userInfoResponse.httpResponse.ToString());
            }
        }
    }
}
