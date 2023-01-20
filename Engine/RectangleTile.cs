using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class RectangleTile : Tile
    {
        public RectangleTile(Vector2 position) : base(position)
        {
            this.position = position;
            Log.InfoMessage($"A new rectangle tile was created at {this.position.x} , {this.position.y} position.");
        }
    }
}
