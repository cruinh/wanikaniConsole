using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaniKani
{
    class RadicalsPrinter
    {
        public static void print(IEnumerable<Radical> radicals)
        {
            foreach (var radical in radicals)
            {
                RadicalsPrinter.print(radical);
            }
        }

        public static void print(Radical radical)
        {
            Console.Write(" {0}\n", radical.character);
            Console.Write("   meaning : \"{0}\"\n", radical.meaning);
            Console.Write("   onyomi : \"{0}\"\n", radical.image);
            Console.Write("   kunyomi : \"{0}\"\n", radical.level);
            Console.Write("\n");
        }
    }
}
