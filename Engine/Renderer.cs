using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    abstract class Renderer
    {
        public abstract void Start();
        public abstract void Render(Tilemap<RectangleTile> map);

        public abstract void NewObject(Type tileObject, char oSign);
        public abstract void NewObject(TileObject tileObject, char oSign);
    }
}
