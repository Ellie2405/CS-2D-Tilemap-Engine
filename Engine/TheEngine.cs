using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    abstract class TheEngine
    {
        public Factory factory;

        public TheEngine()
        {
            factory = new Factory();
        }

        //public void SetTileObject(TileObject obj, Vector2 pos)
        //{
        //    obj.Position = pos;
        //}
    }

    class TestEngine : TheEngine
    {

    }

    class CheckersEngine : TheEngine
    {
        public Tilemap<RectangleTile> map = new Tilemap<RectangleTile>(new Vector2Int(8, 8));

        public void CreateObject(Vector2Int tileIndex, int actor)
        {
            RegularPiece m = factory.TileObjectFacroty<RegularPiece>();
            m.ObjectSetter(actor, "test1", new Vector2Int(tileIndex.x, tileIndex.y));
            map.GetTileByIndexer(tileIndex).SetObjectToTile(m);
        }

        public void Start()
        {
            CreateObject(new Vector2Int(1, 2), 1);
            CreateObject(new Vector2Int(1, 4), 1);
            CreateObject(new Vector2Int(1, 6), 1);
            CreateObject(new Vector2Int(1, 8), 1);
            CreateObject(new Vector2Int(2, 1), 1);
            CreateObject(new Vector2Int(2, 3), 1);
            CreateObject(new Vector2Int(2, 5), 1);
            CreateObject(new Vector2Int(2, 7), 1);
            CreateObject(new Vector2Int(3, 2), 1);
            CreateObject(new Vector2Int(3, 4), 1);
            CreateObject(new Vector2Int(3, 6), 1);
            CreateObject(new Vector2Int(3, 8), 1);
            CreateObject(new Vector2Int(6, 1), 2);
            CreateObject(new Vector2Int(6, 3), 2);
            CreateObject(new Vector2Int(6, 5), 2);
            CreateObject(new Vector2Int(6, 7), 2);
            CreateObject(new Vector2Int(7, 2), 2);
            CreateObject(new Vector2Int(7, 4), 2);
            CreateObject(new Vector2Int(7, 6), 2);
            CreateObject(new Vector2Int(7, 8), 2);
            CreateObject(new Vector2Int(8, 1), 2);
            CreateObject(new Vector2Int(8, 3), 2);
            CreateObject(new Vector2Int(8, 5), 2);
            CreateObject(new Vector2Int(8, 7), 2);
        }
    }
}