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
        public CheckersEngine()
        {
            TileObject.onSteppedCallback += ConvertRegularPiece;
        }

        public Tilemap<RectangleTile> map = new Tilemap<RectangleTile>(new Vector2Int(8, 8));

        public void CreateObject(Vector2Int tileIndex, int actor)
        {
            RegularPiece m = factory.TileObjectFacroty<RegularPiece>();
            m.ObjectSetter(actor, "test1", new Vector2Int(tileIndex.x, tileIndex.y));
            map.GetTileByIndexer(tileIndex).SetObjectToTile(m);
        }

        public void ConvertRegularPiece(TileObject to)
        {
            int actor = (int)to.ObjectActor;
            string id = to.ID;
            Vector2Int index = new Vector2Int(to.Position.x, to.Position.y);
            QueenPiece qp = factory.TileObjectFacroty<QueenPiece>();
            Tile t = map.GetTileByIndexer(index);
            t.RemoveObjectFromTile();
            qp.ObjectSetter(actor, id, index);
            t.SetObjectToTile(qp);
        }

        public void Start()
        {
            CreateObject(new Vector2Int(2, 1), 1);
            CreateObject(new Vector2Int(4, 1), 1);
            CreateObject(new Vector2Int(6, 1), 1);
            CreateObject(new Vector2Int(8, 1), 1);
            CreateObject(new Vector2Int(1, 2), 1);
            CreateObject(new Vector2Int(3, 2), 1);
            CreateObject(new Vector2Int(5, 2), 1);
            CreateObject(new Vector2Int(7, 2), 1);
            CreateObject(new Vector2Int(2, 3), 1);
            CreateObject(new Vector2Int(4, 3), 1);
            CreateObject(new Vector2Int(6, 3), 1);
            CreateObject(new Vector2Int(8, 3), 1);
            //CreateObject(new Vector2Int(1, 6), 2);
            //CreateObject(new Vector2Int(3, 6), 2);
            //CreateObject(new Vector2Int(5, 6), 2);
            //CreateObject(new Vector2Int(7, 6), 2);
            //CreateObject(new Vector2Int(2, 7), 2);
            //CreateObject(new Vector2Int(4, 7), 2);
            //CreateObject(new Vector2Int(6, 7), 2);
            //CreateObject(new Vector2Int(8, 7), 2);
            //CreateObject(new Vector2Int(1, 8), 2);
            //CreateObject(new Vector2Int(3, 8), 2);
            //CreateObject(new Vector2Int(5, 8), 2);
            //CreateObject(new Vector2Int(7, 8), 2);
        }

        public void MoveTileObject(Vector2Int startPos, Vector2Int move)
        {
            TileObject to = map.GetTileObjectByTileIndexer(startPos);
            Tile t = map.GetTileByIndexer(startPos);

            Vector2Int newPosition = to.CalculateNewPosition(move);
            to.SetPosition(newPosition);

            Tile t2 = map.GetTileByIndexer(newPosition);
            to = to.Clone() as TileObject;

            to.SteppedCallBack(t2);

            t.RemoveObjectFromTile();

            //t2.SetObjectToTile(to);



            //if (move.x > 1 && move.y > 1) map.GetTileByIndexer(new Vector2Int(startPos.x + 1, startPos.y + 1)).PassedCallBack();

        }
    }
}