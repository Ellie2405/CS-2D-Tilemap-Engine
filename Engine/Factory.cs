using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class Factory
    {
        public T TileObjectFacroty<T>() where T : TileObject, new()
        {
            return new T();
        }

        public T TileFacroty<T>() where T : Tile, new()
        {
            return new T();
        }
    }
}