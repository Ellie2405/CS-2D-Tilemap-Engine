using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Vector2Int
    {
        public int x { get; private set; }
               
        public int y { get; private set; }

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        #region Spiral variables
        //spiral moves
        public static Vector2Int up => new Vector2Int(0, 1);
        public static Vector2Int down => new Vector2Int(0, -1);
        public static Vector2Int right => new Vector2Int(1, 0);
        public static Vector2Int left => new Vector2Int(-1, 0);
        #endregion

        #region Regular checkers piece moves
        //Regular piece moves
        public static Vector2Int rightDiagonalUp => new Vector2Int(1, -1);
        public static Vector2Int leftDiagonalUp => new Vector2Int(-1, -1);
        public static Vector2Int rightDiagonalDown => new Vector2Int(1, 1);
        public static Vector2Int leftDiagonalDown => new Vector2Int(-1, 1);
        public static Vector2Int rightDiagonalUpEat => new Vector2Int(2, -2);
        public static Vector2Int leftDiagonalUpEat => new Vector2Int(-2, -2);
        public static Vector2Int rightDiagonalDownEat => new Vector2Int(2, 2);
        public static Vector2Int leftDiagonalDownEat => new Vector2Int(-2, 2);
        #endregion

        #region Queen checkers piece moves
        //Queen piece moves
        public static Vector2Int rightDiagonalUp2 => new Vector2Int(2, -2);
        public static Vector2Int rightDiagonalUp3 => new Vector2Int(3, -3);
        public static Vector2Int rightDiagonalUp4 => new Vector2Int(4, -4);
        public static Vector2Int rightDiagonalUp5 => new Vector2Int(5, -5);
        public static Vector2Int rightDiagonalUp6 => new Vector2Int(6, -6);
        public static Vector2Int rightDiagonalUp7 => new Vector2Int(7, -7);

        public static Vector2Int leftDiagonalUp2 => new Vector2Int(-2, -2);
        public static Vector2Int leftDiagonalUp3 => new Vector2Int(-3, -3);
        public static Vector2Int leftDiagonalUp4 => new Vector2Int(-4, -4);
        public static Vector2Int leftDiagonalUp5 => new Vector2Int(-5, -5);
        public static Vector2Int leftDiagonalUp6 => new Vector2Int(-6, -6);
        public static Vector2Int leftDiagonalUp7 => new Vector2Int(-7, -7);

        public static Vector2Int rightDiagonalDown2 => new Vector2Int(2, 2);
        public static Vector2Int rightDiagonalDown3 => new Vector2Int(3, 3);
        public static Vector2Int rightDiagonalDown4 => new Vector2Int(4, 4);
        public static Vector2Int rightDiagonalDown5 => new Vector2Int(5, 5);
        public static Vector2Int rightDiagonalDown6 => new Vector2Int(6, 6);
        public static Vector2Int rightDiagonalDown7 => new Vector2Int(7, 7);

        public static Vector2Int leftDiagonalDown2 => new Vector2Int(-2, 2);
        public static Vector2Int leftDiagonalDown3 => new Vector2Int(-3, 3);
        public static Vector2Int leftDiagonalDown4 => new Vector2Int(-4, 4);
        public static Vector2Int leftDiagonalDown5 => new Vector2Int(-5, 5);
        public static Vector2Int leftDiagonalDown6 => new Vector2Int(-6, 6);
        public static Vector2Int leftDiagonalDown7 => new Vector2Int(-7, 7);
        #endregion

        public override string ToString()
        {
            return ($"x {x}, y {y}");
        }

        public override bool Equals(object? obj)
        {
            var d = (Vector2Int)obj;
            return this.x == d.x && this.y == d.y;
        }

        public override int GetHashCode() 
        {
            int X = x < 0 ? 0 : 1;
            int Y = y < 0 ? 0 : 1;
            return X * 100_000 + Math.Abs(x) * 1_000 + Y * 100 + Math.Abs(y);

        }

        public Vector2Int AddVector(Vector2Int vector)
        {
            return new Vector2Int(this.x + vector.x, this.y + vector.y);
        }

        public Vector2Int SubtractVector(Vector2Int vector)
        {
            return new Vector2Int(this.x - vector.x, this.y - vector.y);
        }

        public static Vector2Int operator +(Vector2Int vector, Vector2Int vector2)
        {
            return new Vector2Int(vector.x + vector2.x, vector.y + vector2.y);
        }

        public static Vector2Int operator -(Vector2Int vector, Vector2Int vector2)
        {
            return new Vector2Int(vector.x - vector2.x, vector.y - vector2.y);
        }
    }
}
