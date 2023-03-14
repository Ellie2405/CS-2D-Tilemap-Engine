﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class TileRenderer
    {
        public static List<ConsoleColor> BoardColors { get; private set; } = new List<ConsoleColor>()
        {
            ConsoleColor.White,
            ConsoleColor.DarkGray,
        };
        public static List<ConsoleColor> TeamColors { get; private set; } = new List<ConsoleColor>()
        {
            ConsoleColor.White,
            ConsoleColor.Black,
        };
        static char bracketSignOpen = ' ';
        static char bracketSignClose = ' ';
        ConsoleColor selectionColor = ConsoleColor.Yellow;
        ConsoleColor tileTextColor = ConsoleColor.Gray;
        ConsoleColor objectTextColor = ConsoleColor.Gray;
        char objectSign = ' ';


        public TileRenderer(char sign)
        {
            objectSign = sign;
        }

        public void Print()
        {

        }

        public void Print(int duoColorIndex, int actorIndex)
        {
            Console.BackgroundColor = BoardColors[duoColorIndex];
            Console.ForegroundColor = TeamColors[actorIndex];
            Console.Write(bracketSignOpen);
            Console.Write(objectSign);
            Console.Write(bracketSignClose);
            Console.BackgroundColor = default;
            Console.ForegroundColor = objectTextColor;
        }

        static public void PrintEmpty(int duoColorIndex)
        {
            Console.BackgroundColor = BoardColors[duoColorIndex];
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(bracketSignOpen + " ");
            Console.Write(bracketSignClose);
            Console.BackgroundColor = default;
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        static public void SetBoardColor(ConsoleColor color1 = ConsoleColor.White, ConsoleColor color2 = ConsoleColor.DarkGray)
        {
            BoardColors[0] = color1;
            BoardColors[1] = color2;
        }

        static public void SetActorColor(ConsoleColor color1, ConsoleColor color2)
        {
            TeamColors[0] = color1;
            TeamColors[1] = color2;
        }

        static public void SetBracketChars(char a,char b)
        {
            bracketSignOpen = a;
            bracketSignClose = b;

        }

        public void SignPrint()
        {
            Console.Write(objectSign);

        }

    }
}
