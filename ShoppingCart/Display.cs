using System;
using System.Threading;

namespace ShoppingCart
{
    public class Display
    {
        //public static bool Pretty { get; set; }
        public static void ShowMessage(string message)
        {
            System.Console.WriteLine(message);
        }

        public static string GetInputFromUser(string message)
        {
            System.Console.WriteLine(message);
            return System.Console.ReadLine();
        }
        public static void GetInputFromUser(string message, out string input)
        {
            System.Console.WriteLine(message);
            input = System.Console.ReadLine();
        }

        public static void ShowMessagePretty(string message)
        {
            System.Console.WriteLine("-------------------------------------------------");
            System.Console.WriteLine(message);
            System.Console.WriteLine("-------------------------------------------------");
        }

        public static string GetInputFromUserPretty(string message)
        {
            string input = "";
            System.Console.WriteLine("-------------------------------------------------");
            var inputThread = new Thread(()=>GetInputFromUser(message, out input));
            inputThread.Start();
            System.Console.WriteLine("-------------------------------------------------");
            inputThread.Join();
            return input;
        }
    }
}
