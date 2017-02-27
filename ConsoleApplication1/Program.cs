using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace WaniKani
{
    public class WaniKaniConsole
    {
        private static SDK sdk;
        private static UserInfo userInfo;
        private static UserInfoDialog userInfoDialog;

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
            Console.WriteLine("NOTE: If you haven't yet, set your console to output using fonts MS Gothic or MS Mincho.\n");
        }

        private static void showMenu()
        {
            Console.WriteLine("Choose from the following API requests:");
            Console.WriteLine("   0: User Profile");
            Console.WriteLine("   1: Radicals List");
            Console.WriteLine("   2: Kanji List");
            Console.WriteLine("\nAny other key to exit");

            parseMenuInput();
        }

        private static void parseMenuInput()
        {
            Console.Write("\n> ");
            var key = Console.ReadKey().Key;
            Console.WriteLine("\n");

            if (key == ConsoleKey.NumPad0 || key == ConsoleKey.D0)
            {
                if (userInfo != null)
                {
                    userInfoDialog = new UserInfoDialog(userInfo);
                    userInfoDialog.show();
                }
                else
                {
                    Console.WriteLine("[--ERROR--]: No user information to display");
                }
                showMenu();
                parseMenuInput();
            }
            else if (key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
            {
                sdk.requestUnlockedRadicals(responseHandler);
                showMenu();
                parseMenuInput();
            }
            else if (key == ConsoleKey.NumPad2 || key == ConsoleKey.D2)
            {
                sdk.requestUnlockedKanji(responseHandler);
                showMenu();
                parseMenuInput();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private static void printOutro()
        {
            Console.WriteLine("\nPress the Any key to quit.");
            Console.ReadKey();
        }

        private static void responseHandler(IWaniKaniResponse waniKaniResponse)
        {
            if (waniKaniResponse is UserInfoResponse)
            {
                userInfo = waniKaniResponse.user_information;
                UserInfoReponsePrinter.print((UserInfoResponse)waniKaniResponse);
            }
            else if (waniKaniResponse is KanjiResponse)
            {
                KanjiResponsePrinter.print((KanjiResponse)waniKaniResponse);
            }
            else if (waniKaniResponse is RadicalsResponse)
            {
                RadicalsResponsePrinter.print((RadicalsResponse)waniKaniResponse);
            }
        }

        static void Main(string[] args)
        {
            setup();

            printIntro();

            sdk.requestUserInformation(responseHandler);

            showMenu();
            printOutro();
        }
    }
}