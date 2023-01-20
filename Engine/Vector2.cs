using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Vector2
    {
        public float x { get; private set; }

        public float y { get; private set; }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 up => new Vector2(0, 1);
        public static Vector2 down => new Vector2(0, -1);
        public static Vector2 right => new Vector2(1, 0);
        public static Vector2 left => new Vector2(-1, 0);

        public override string ToString()
        {
            return ($"x {x}, y {y}");
        }

        public override bool Equals(object? obj)
        {
            var d = (Vector2)obj;
            return this.x == d.x && this.y == d.y;
        }

        public override int GetHashCode() //redo this pls
        {
            return (int)x + (int)y;
        }

        public Vector2 AddVector(Vector2 vector)
        {
            return new Vector2(this.x + vector.x, this.y + vector.y);
        }

        public Vector2 SubtractVector(Vector2 vector)
        {
            return new Vector2(this.x - vector.x, this.y - vector.y);
        }
    }
}
