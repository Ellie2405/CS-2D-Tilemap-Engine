using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Log
    {
        //public static Queue<string> log = new Queue<string>();

        public static void RegularMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[MSG] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 30);
        }
        public static void InfoMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[INFO] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 30);
        }
        public static void WarningMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 30);
        }
        public static void ErrorMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 30);
        }
    }
}
