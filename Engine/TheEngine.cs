﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    abstract class TheEngine
    {
        public static Vector2Int indexer { get; protected set; } = new(4, 4);

    }



    class CheckersEngine : TheEngine
    {
        public static event Action<Vector2Int> onPassedTile;
        public CheckersEngine()
        {
            TileObject.onSteppedCallback += ConvertRegularPiece;
        }

        public Tilemap<RectangleTile> map;
        public TileObject? selectedObject;
        static public List<Vector2Int> validPositions = new List<Vector2Int>();

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
            CreateTileObject<QueenPiece>(new Vector2Int(6, 3), 1);
            CreateTileObject<RegularPiece>(new Vector2Int(4, 5), 1);
            CreateTileObject<RegularPiece>(new Vector2Int(3, 6), 2);
        }

        public void Update()
        {
            bool _isDone = false;

            while (_isDone == false)
            {
                GetInput();

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    _isDone = true;
                }
            }
        }

        public void CreateTileMap<T>()
        {
            map = Factory.TileMapFactory<Tilemap<RectangleTile>, RectangleTile>();
            map.InitializeTileMap(new Vector2Int(8, 8));
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
            Tile t, t2;
            TileObject to = map.GetTileObjectByTileIndexer(startPos);
            t = map.GetTileByIndexer(startPos);
            Vector2Int newPosition = to.CalculateNewPosition(move);
            if (!ExtensionMethods.In2DArrayBounds(map.grid, newPosition))
                return false;
            t2 = map.GetTileByIndexer(newPosition);


            if
                (to is RegularPiece && to.ObjectActor == TileObject.Actor.Player1
                && newPosition.y > startPos.y && t2.tileObject == null
                && t2.state != Tile.State.Hole) // last condition is movement mazochist
            {
                if (move.Equals(Vector2Int.leftDiagonalDownEat)
                    || move.Equals(Vector2Int.rightDiagonalDownEat))
                {
                    if (map.CheckForTileObject(newPosition.AddVector(StepBack(move))))
                    {
                        if(map.GetTileObjectByTileIndexer(newPosition.AddVector(StepBack(move))).ObjectActor == TileObject.Actor.Player2) 
                            return true;
                    }
                    else return false;
                }
                else return true;
                //MoveTileObject(startPos, move);
            }


            else if
                (to is RegularPiece && to.ObjectActor == TileObject.Actor.Player2
                && newPosition.y < startPos.y && t2.tileObject == null
                && t2.state != Tile.State.Hole)
            {
                if (move.Equals(Vector2Int.leftDiagonalUpEat)
                    || move.Equals(Vector2Int.rightDiagonalUpEat))
                {
                    if (map.CheckForTileObject(newPosition.AddVector(StepBack(move))))
                    {
                        if (map.GetTileObjectByTileIndexer(newPosition.AddVector(StepBack(move))).ObjectActor == TileObject.Actor.Player1)
                            return true;
                    }
                    else return false;
                }
                else return true;
                //MoveTileObject(startPos, move);
            }


            else if
                (to is QueenPiece && t2.tileObject == null
                && t2.state != Tile.State.Hole)
            {
                //MoveTileObject(startPos, move);
                return true;
            }

            return false;
        }

        public void GetInput()
        {
            ConsoleKey i = Console.ReadKey().Key;

            switch (i)
            {
                case ConsoleKey.UpArrow:
                    indexer = new Vector2Int(indexer.x, indexer.y - 1);
                    break;
                case ConsoleKey.DownArrow:
                    indexer = new Vector2Int(indexer.x, indexer.y + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    indexer = new Vector2Int(indexer.x - 1, indexer.y);
                    break;
                case ConsoleKey.RightArrow:
                    indexer = new Vector2Int(indexer.x + 1, indexer.y);
                    break;
                case ConsoleKey.Enter:
                    if (map.CheckForTileObject(indexer))
                    {
                        selectedObject = map.GetTileObjectByTileIndexer(indexer);

                        GetValidatedMoves(selectedObject);
                    }
                    break;
                default:
                    break;
            }

            if (indexer.x > map.gridSize.x)
                indexer = new Vector2Int(map.gridSize.x, indexer.y);
            else if (indexer.x < 1)
                indexer = new Vector2Int(1, indexer.y);
            else if (indexer.y > map.gridSize.y)
                indexer = new Vector2Int(indexer.x, map.gridSize.y);
            else if (indexer.y < 1)
                indexer = new Vector2Int(indexer.x, 1);

        }

        public void GetValidatedMoves(TileObject to)
        {
            foreach (var item in to.moves)
            {
                if (ValidateMove(to.Position, item.Value))
                {
                    validPositions.Add(to.Position + item.Value);
                    Console.WriteLine(item.Value);
                }
            }
        }
    }
}