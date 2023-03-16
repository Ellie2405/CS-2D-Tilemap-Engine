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
        public static Vector2Int indexer { get; protected set; } = new(1, 1);

        public virtual void GetInput()
        {
            ConsoleKey i = Console.ReadKey().Key;

            switch(i)
            {
                case ConsoleKey.UpArrow:
                    indexer = new Vector2Int(indexer.x, indexer.y - 1);
                    break; 
                case ConsoleKey.DownArrow:
                    indexer = new Vector2Int(indexer.x, indexer.y + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    indexer = new Vector2Int(indexer.x + 1, indexer.y);
                    break;
                case ConsoleKey.RightArrow:
                    indexer = new Vector2Int(indexer.x - 1, indexer.y);
                    break;
                default:
                    break;
            }
        }
    }



    class CheckersEngine : TheEngine
    {
        public static event Action<Vector2Int> onPassedTile;
        public CheckersEngine()
        {
            TileObject.onSteppedCallback += ConvertRegularPiece;
        }

        public Tilemap<RectangleTile> map;

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
            CreateTileMap<Tilemap<RectangleTile>>();
            CreateTileObject<QueenPiece>(new Vector2Int(6, 5), 1);
            CreateTileObject<RegularPiece>(new Vector2Int(4, 3), 2);
        }

        public void CreateTileMap<T>()
        {
            map = Factory.TileMapFactory<Tilemap<RectangleTile>, RectangleTile>();
            map.InitializeTileMap(new Vector2Int(8,8));
        }

        public void CreateTileObject<T>(Vector2Int tileIndex, int actor) where T : TileObject, new()
        {
            T m = Factory.TileObjectFactory<T>();
            m.ObjectSetter(actor, new Vector2Int(tileIndex.x, tileIndex.y));

            Tile t = map.GetTileByIndexer(tileIndex);
            t.SetObjectToTile(m);
        }

        public void ConvertRegularPiece(TileObject to)
        {
            int actor = 0;
            if (to.ObjectActor == TileObject.Actor.Player1) actor = 1;
            else if (to.ObjectActor == TileObject.Actor.Player2) actor = 2;
            Vector2Int index = new Vector2Int(to.Position.x, to.Position.y);

            QueenPiece qp = Factory.TileObjectFactory<QueenPiece>();
            Tile t = map.GetTileByIndexer(index);

            t.PassedCallBack();
            qp.ObjectSetter(actor, index);
            t.SetObjectToTile(qp);
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

            if (map.CheckForTileObject(newPosition.AddVector(StepBack(move)))) onPassedTile.Invoke(newPosition.AddVector(StepBack(move)));
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


            if
                (to is RegularPiece && to.ObjectActor == TileObject.Actor.Player1
                && newPosition.y! < startPos.y && t2.tileObject == null
                && newPosition.x <= map.gridSize.x && newPosition.y <= newPosition.y
                && newPosition.x <= 0 && newPosition.y <= 0
                && t2.state != Tile.State.Hole) // last condition is movement mazochist
            {
                MoveTileObject(startPos, move);
                return true;
            }


            else if
                (to is RegularPiece && to.ObjectActor == TileObject.Actor.Player2
                && newPosition.y! > startPos.y && t2.tileObject == null
                && newPosition.x <= map.gridSize.x && newPosition.y <= newPosition.y
                && newPosition.x <= 0 && newPosition.y <= 0
                && t2.state != Tile.State.Hole)
            {
                MoveTileObject(startPos, move);
                return true;
            }


            else if
                (to is QueenPiece && t2.tileObject == null
                && t2.state != Tile.State.Hole)
            {
                MoveTileObject(startPos, move);
            }

            return false;
        }

        public override void GetInput()
        {
            base.GetInput();

            if (indexer.x > map.gridSize.x)
                indexer = new Vector2Int(map.gridSize.x, indexer.y);
            else if (indexer.x < map.gridSize.x)
                indexer = new Vector2Int(1, indexer.y);
            else if (indexer.y > map.gridSize.y)
                indexer = new Vector2Int(indexer.x, map.gridSize.y);
            else if (indexer.y < map.gridSize.y)
                indexer = new Vector2Int(indexer.x, 1);
        }
    }
}