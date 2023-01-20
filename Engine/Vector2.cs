using System;
using System.Collections.Generic;
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
            return ($"{ x } , { y }") ;
        }
    }
}
