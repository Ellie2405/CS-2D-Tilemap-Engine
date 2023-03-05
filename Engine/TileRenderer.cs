using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class TileRenderer//<T> where T : TileObject
    {
        char objectSign = ' ';
        ConsoleColor tileBGColor;
        ConsoleColor tileTextColor = ConsoleColor.Gray;
        ConsoleColor objectBGColor;
        ConsoleColor objectTextColor = ConsoleColor.Gray;

        public TileRenderer(char sign)
        {
            objectSign = sign;
        }

        public void Print()
        {
            Console.BackgroundColor = tileBGColor;
            Console.ForegroundColor = tileTextColor;
            Console.Write('[');
            Console.BackgroundColor = objectBGColor;
            Console.ForegroundColor = objectTextColor;
            Console.Write(objectSign);
            Console.BackgroundColor = tileBGColor;
            Console.ForegroundColor = tileTextColor;
            Console.Write(']');
        }

        static public void PrintEmpty()
        {
            Console.Write("[ ");
            Console.Write(']');

        }
        public void SignPrint()
        {
            Console.Write(objectSign);
        }
    }
}
