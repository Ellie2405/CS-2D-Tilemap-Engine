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
    }

  

    class CheckersEngine : TheEngine
    {
        public static Action OnPassedTile;
        public CheckersEngine()
        {
            TileObject.onSteppedCallback += ConvertRegularPiece;
        }

        public Tilemap<RectangleTile> map = new Tilemap<RectangleTile>(new Vector2Int(8, 8));



        public void CreateRegularPiece(Vector2Int tileIndex, int actor)
        {
            RegularPiece m = factory.TileObjectFacroty<RegularPiece>();
            m.ObjectSetter(actor, "test1", new Vector2Int(tileIndex.x, tileIndex.y));

            Tile t = map.GetTileByIndexer(tileIndex);
            t.SetObjectToTile(m);
        }

        public void CreateQueenPiece(Vector2Int tileIndex, int actor)
        {
            QueenPiece m = factory.TileObjectFacroty<QueenPiece>();
            m.ObjectSetter(actor, "test1", new Vector2Int(tileIndex.x, tileIndex.y));

            Tile t = map.GetTileByIndexer(tileIndex);
            t.SetObjectToTile(m);
        }



        public void ConvertRegularPiece(TileObject to)
        {
            int actor = 0;
            if (to.ObjectActor == TileObject.Actor.Player1) actor = 1;
            else if (to.ObjectActor == TileObject.Actor.Player2) actor = 2;
            string id = to.ID;
            Vector2Int index = new Vector2Int(to.Position.x, to.Position.y);

            QueenPiece qp = factory.TileObjectFacroty<QueenPiece>();
            Tile t = map.GetTileByIndexer(index);

            t.PassedCallBack();
            qp.ObjectSetter(actor, id, index);
            t.SetObjectToTile(qp);
        }

        public void Start()
        {
            //CreateObject(new Vector2Int(2, 1), 1);
            //CreateObject(new Vector2Int(4, 1), 1);
            //CreateObject(new Vector2Int(6, 1), 1);
            //CreateObject(new Vector2Int(8, 1), 1);
            //CreateObject(new Vector2Int(1, 2), 1);
            //CreateObject(new Vector2Int(3, 2), 1);
            //CreateObject(new Vector2Int(5, 2), 1);
            //CreateObject(new Vector2Int(7, 2), 1);
            //CreateObject(new Vector2Int(2, 3), 1);
            //CreateObject(new Vector2Int(4, 3), 1);
            //CreateObject(new Vector2Int(6, 3), 1);
            //CreateObject(new Vector2Int(8, 3), 1);
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
            CreateQueenPiece(new Vector2Int(6, 5), 1);
            CreateRegularPiece(new Vector2Int(4, 3), 2);
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

            t.PassedCallBack();

            if (map.CheckForTileObject(newPosition.AddVector(StepBack(move)))) map.GetTileByIndexer(newPosition.AddVector(StepBack(move))).PassedCallBack();
        }

        public Vector2Int StepBack(Vector2Int vector)
        {
            return new Vector2Int(Math.Abs(vector.x) / -vector.x, Math.Abs(vector.y) / -vector.y);
        }

        public bool ValidateMove(Vector2Int startPos, Vector2Int move)
        {
            TileObject to = map.GetTileObjectByTileIndexer(startPos);
            Tile t = map.GetTileByIndexer(startPos);
            Vector2Int newPosition = to.CalculateNewPosition(move);
            Tile t2 = map.GetTileByIndexer(newPosition);


            if (to is RegularPiece && to.ObjectActor == TileObject.Actor.Player1 
                && newPosition.y! < startPos.y && t2.tileObject == null 
                && newPosition.x <= map.gridSize.x && newPosition.y <= newPosition.y
                && newPosition.x <= 0 && newPosition.y <= 0)
            {
                MoveTileObject(startPos, move);
                return true;
            }


            else if (to is RegularPiece && to.ObjectActor == TileObject.Actor.Player2
                && newPosition.y! > startPos.y && t2.tileObject == null
                && newPosition.x <= map.gridSize.x && newPosition.y <= newPosition.y
                && newPosition.x <= 0 && newPosition.y <= 0)
            {
                MoveTileObject(startPos, move);
                return true;
            }


            else if(to is QueenPiece && t2.tileObject == null)
            {
                MoveTileObject(startPos, move);
            }

            return false;
        }
    }
}