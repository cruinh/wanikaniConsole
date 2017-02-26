using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    class ItemUserInfoPrinter
    {
        public static void print(ItemUserInfo itemUserInfo)
        {
            Console.Write("   unlocked_date : \"{0}\"\n", itemUserInfo.unlocked_date_native);
            Console.Write("   user_synonyms : ");
            if (itemUserInfo.user_synonyms != null)
            {
                foreach (var synonym in itemUserInfo.user_synonyms)
                {
                    if (synonym != itemUserInfo.user_synonyms.First<String>())
                    {
                        Console.Write(", ");
                    }
                    Console.Write("\"{0}\"", synonym);
                }
            }
            else
            {
                Console.Write("(none)");
            }
            Console.Write("\n");
            Console.Write("   meaning_note : \"{0}\"\n", itemUserInfo.meaning_note);
            Console.Write("   reading_note : \"{0}\"\n", itemUserInfo.reading_note);
            Console.Write("   srs : \"{0}\"\n", itemUserInfo.srs);
            Console.Write("   srs_numeric : \"{0}\"\n", itemUserInfo.srs_numeric);
            Console.Write("   available_date : \"{0}\"\n", itemUserInfo.available_date_native);
            Console.Write("   burned : \"{0}\"\n", itemUserInfo.burned);
            Console.Write("   burned_date : \"{0}\"\n", itemUserInfo.burned_date_native);
            Console.Write("   reactivated_date : \"{0}\"\n", itemUserInfo.reactivated_date_native);
            Console.Write("   meaning_correct : \"{0}\"\n", itemUserInfo.meaning_correct);
            Console.Write("   meaning_incorrect : \"{0}\"\n", itemUserInfo.meaning_incorrect);
            Console.Write("   meaning_max_streak : \"{0}\"\n", itemUserInfo.meaning_max_streak);
            Console.Write("   meaning_current_streak : \"{0}\"\n", itemUserInfo.meaning_current_streak);
            Console.Write("   reading_correct : \"{0}\"\n", itemUserInfo.reading_correct);
            Console.Write("   reading_incorrect : \"{0}\"\n", itemUserInfo.reading_incorrect);
            Console.Write("   reading_max_streak : \"{0}\"\n", itemUserInfo.reading_max_streak);
            Console.Write("   reading_current_streak : \"{0}\"\n", itemUserInfo.reading_current_streak);

            Console.Write("\n");
        }
    }
}
