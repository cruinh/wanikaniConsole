using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace WaniKani {

    public class WaniKaniConsole
    {
        private static SDK sdk;

        private static string apiKeyPath()
        {
            string projectBuildPath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            string filePath = Directory.GetParent(Directory.GetParent(projectBuildPath).FullName).FullName + @"\apiKey.txt";
            return filePath;
        }

        private static string readAPIKey()
        {
            string filePath = apiKeyPath();
            return System.IO.File.ReadAllText(filePath);
        }

        private static void setup()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string apiKey = readAPIKey();
            sdk = new SDK(apiKey);
        }

        private static void printIntro()
        {
            Console.WriteLine("Welcome to WaniKani API Test!\n....\n");
            Console.WriteLine("\tNOTE: If you haven't yet, set your console to output using fonts MS Gothic or MS Mincho.\n");
        }

        private static void printOutro()
        {
            Console.WriteLine("\nPress the Any key to quit.");
            Console.ReadKey();
        }

        private static void requestAndPrintKanji()
        {
            Action<KanjiResponse> responseHandler = delegate (KanjiResponse kanjiResponse)
            {
                KanjiPrinter.print(kanjiResponse);
            };
            sdk.requestKanji(responseHandler);
        }

        static void Main(string[] args)
        {
            setup();

            printIntro();
            requestAndPrintKanji();
            printOutro();
        }
    }
}