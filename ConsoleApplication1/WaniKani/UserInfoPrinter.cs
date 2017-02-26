using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    public class UserInfoPrinter
    {
        public static void print(UserInfo userInfo)
        {
            Console.WriteLine("{0}", userInfo.username);
        }
    }
}
