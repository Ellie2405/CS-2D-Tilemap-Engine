﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal static class ExtensionMethods
    {
        public static string TrimAndLowerCapString(string str)
        {
            return str.Trim().ToLower();
        }

        public static bool In2DArrayBounds(object[,] array, int x, int y)
        {
            if (x < array.GetLowerBound(0) || x > array.GetUpperBound(0) || y < array.GetLowerBound(1) || y > array.GetUpperBound(1)) 
                return false;
            return true;
        }

        public static bool CheckArrayNullOrBigger(object[,] array)
        {
            if (array.Length == 0 || array.Length < 0)
                return true;
            return false;
        }
    }
}