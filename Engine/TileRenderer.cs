using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class TileRenderer
    {
        char objectSign = ' ';
        ConsoleColor tileBGColor;
        ConsoleColor tileTextColor = ConsoleColor.Gray;
        ConsoleColor objectBGColor;
        ConsoleColor objectTextColor;

        public TileRenderer()
        {

        }

        public void PrintTile()
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
