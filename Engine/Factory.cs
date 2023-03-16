using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Factory
    {
        public static T TileObjectFactory<T>() where T : TileObject, new()
        {
            return new T();
        }

        public static T TileFactory<T>() where T : Tile, new()
        {
            return new T();
        }

        public static T1 TileMapFactory<T1, T2>() 
            where T1 : Tilemap<T2>, new()
            where T2 : Tile, new() 
        {
            return new T1();
        }
    }
}