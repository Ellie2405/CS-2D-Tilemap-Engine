using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class TileRenderer<T> where T : TileObject
    {
        char objectSign = ' ';
        ConsoleColor tileBGColor;
        ConsoleColor tileTextColor = ConsoleColor.Gray;
        ConsoleColor objectBGColor;
        ConsoleColor objectTextColor;

        public TileRenderer(char sign)
        {
            this.objectSign = sign;
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
    }
}
