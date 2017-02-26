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
            Console.Write(" {0}\n", userInfo.username);
            Console.Write("   gravatar : \"{0}\"\n", userInfo.gravatar);
            Console.Write("   level : \"{0}\"\n", userInfo.level);
            Console.Write("   title : \"{0}\"\n", userInfo.title);
            Console.Write("   about : \"{0}\"\n", userInfo.about);
            Console.Write("   website : {0}\n", userInfo.website);
            Console.Write("   twitter : \"{0}\"\n", userInfo.twitter);
            Console.Write("   topics_count : \"{0}\"\n", userInfo.topics_count);
            Console.Write("   creation_date : \"{0}\"\n", userInfo.creation_date_native);
            Console.Write("   vacation_date : \"{0}\"\n", userInfo.vacation_date_native);
            Console.Write("\n");
        }
    }
}
