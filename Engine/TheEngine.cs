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

    class CheckersEngine: TheEngine
    {
        public Tilemap<RectangleTile> map = new Tilemap<RectangleTile>(new Vector2(8,8));

        public void CreateObject(Vector2 tileIndex, int actor)
        {
            Man m = factory.TileObjectFacroty<Man>();
            m.ObjectSetter(actor, "test1");
            map.grid[(int)tileIndex.x - 1, (int)tileIndex.y- 1].TileObjectSetter(m);
        }

        public void Start()
        {
            CreateObject(new Vector2(1, 2), 1);
            CreateObject(new Vector2(1, 4), 1);
            CreateObject(new Vector2(1, 6), 1);
            CreateObject(new Vector2(1, 8), 1);
            CreateObject(new Vector2(2, 1), 1);
            CreateObject(new Vector2(2, 3), 1);
            CreateObject(new Vector2(2, 5), 1);
            CreateObject(new Vector2(2, 7), 1);
            CreateObject(new Vector2(3, 2), 1);
            CreateObject(new Vector2(3, 4), 1);
            CreateObject(new Vector2(3, 6), 1);
            CreateObject(new Vector2(3, 8), 1);
            CreateObject(new Vector2(6, 1), 2);
            CreateObject(new Vector2(6, 3), 2);
            CreateObject(new Vector2(6, 5), 2);
            CreateObject(new Vector2(6, 7), 2);
            CreateObject(new Vector2(7, 2), 2);
            CreateObject(new Vector2(7, 4), 2);
            CreateObject(new Vector2(7, 6), 2);
            CreateObject(new Vector2(7, 8), 2);
            CreateObject(new Vector2(8, 1), 2);
            CreateObject(new Vector2(8, 3), 2);
            CreateObject(new Vector2(8, 5), 2);
            CreateObject(new Vector2(8, 7), 2);
        }
    }
}