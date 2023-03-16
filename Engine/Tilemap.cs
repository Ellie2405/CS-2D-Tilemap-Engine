using Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// A collection object, creates a 2D array, has its own enumerator and uses an interface to manipulate its data.
    /// Uses an int indexer to traverse through the collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tilemap<T> : ICheckersMapTools, IEnumerable<Tile> where T : Tile, new()
    {

        public T[,] grid;
        //public Vector2 testStartPos = new Vector2(4, 4); // uncomment and insert in GetEnumerator() if you want to use the spiral enumerator
        public Vector2Int gridSize = new Vector2Int(8, 8);
        private Vector2Int indexValue = new Vector2Int(1, 1);

        public void InitializeTileMap(Vector2Int gridSize)
        {
            SetGridSize(gridSize);
            InjectTiles(gridSize, grid);
            SetIndexersInMap();
            GetEnumerator();
            CheckersEngine.onPassedTile += RemoveObjectFromTile;
        }

        public void SetGridSize(Vector2Int gridSize)
        {
            grid = new T[gridSize.x, gridSize.y];
            this.gridSize = gridSize;
        }

        public void InjectTiles(Vector2Int gridSize, Tile[,] grid)
        {
            for (int i = 0; i < gridSize.y; i++)
            {
                for (int j = 0; j < gridSize.x; j++)
                {
                    grid[j, i] = Factory.TileFactory<T>();
                }
            }
        }

        public void SetIndexersInMap()
        {
            foreach (var item in grid)
            {
                item.SetIndexer(indexValue);
                indexValue = new Vector2Int(indexValue.x + 1, indexValue.y);
                if (indexValue.x == grid.GetLength(0) + 1) indexValue = new Vector2Int(1, indexValue.y + 1);
            }
        }

        public Tile GetTileByIndexer(Vector2Int index)
        {
            foreach (var item in grid)
            {
                if (item.indexer.x == index.x && item.indexer.y == index.y) return item;
            }

            throw new Exception("Tile doesnt exist");
        }

        public TileObject GetTileObjectByTileIndexer(Vector2Int index)
        {
            foreach (var item in grid)
            {
                if (item.indexer.x == index.x && item.indexer.y == index.y && item.tileObject != null) return item.tileObject;
            }

            throw new Exception("Tile doesnt exist or Tile object is null");
        }

        public bool CheckForTileObject(Vector2Int index)
        {
            foreach (var item in grid)
            {
                if (item.indexer.x == index.x && item.indexer.y == index.y && item.tileObject != null) return true;

                else if (item.indexer.x == index.x && item.indexer.y == index.y && item.tileObject == null) return false;
            }
            return false;
        }

        public void RemoveObjectFromTile(Vector2Int index)
        {
            foreach (var item in grid)
            {
                if (item.indexer.x == index.x && item.indexer.y == index.y) item.PassedCallBack();
            }
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            return new TilemapEnumerator<Tile>(grid);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public struct TilemapEnumerator<Tile> : IEnumerator<Tile>
    {
        Vector2Int index = new Vector2Int(-1, 0);
        Tile[,] enumerables;

        public TilemapEnumerator(Tile[,] enumerables)
        {
            this.enumerables = enumerables;
        }

        public Tile Current()
        {
            if (index.x < enumerables.GetLength(0) && index.y < enumerables.GetLength(1) && index.x >= 0 && index.y >= 0) return enumerables[(int)index.x, (int)index.y];
            else throw new Exception("failed");
        }

        object IEnumerator.Current => Current;

        Tile IEnumerator<Tile>.Current => Current();

        public bool MoveNext()
        {
            //if (index.y < enumerables.GetLength(1) - 1) index = new Vector2Int(index.x, index.y + 1);
            //else if (index.y == enumerables.GetLength(1) - 1) index = new Vector2Int(index.x + 1, 0);
            if (index.x < enumerables.GetLength(0) - 1) index = new Vector2Int(index.x + 1, index.y);
            else if (index.x == enumerables.GetLength(0) - 1) index = new Vector2Int(0, index.y + 1);


            return index.x < enumerables.GetLength(0) && index.y < enumerables.GetLength(1);
        }

        public void Dispose() { }

        public void Reset() { }
    }

    public struct SpiralEnumerator<Tile> : IEnumerator<Tile>
    {
        Vector2Int index;
        Tile[,] enumerables;


        public SpiralEnumerator(Tile[,] enumerables, Vector2Int index)
        {
            this.enumerables = enumerables;
            this.index = index;
        }

        public Tile Current()
        {
            if (index.x < enumerables.GetLength(0) && index.y < enumerables.GetLength(1) && index.x >= 0 && index.y >= 0) return enumerables[(int)index.x, (int)index.y];
            else throw new Exception("failed");
        }

        object IEnumerator.Current => Current;

        Tile IEnumerator<Tile>.Current => Current();

        #region spiral logic variables
        int d = -1;  // direction, changes when moved enough in said direction (more than l)
        int l = 0;  // how much to move in said direction
        int s = 0;  // how much it has already moved in said direction
        int t = 1; // turn counter, after turning twice l should increase
        #endregion

        public bool MoveNext()
        {
            //if moved enough in the current direction, change direction and reset step counter, and count 1 direction change
            if (s >= l)
            {
                d++;
                s = 0;
                t++;

                Console.WriteLine($"Current is {index.x}, {index.y}");
            }

            //every 2 direction changes, increase how much you move in each direction and reset turn counter
            if (t == 2)
            {
                l++;
                Console.WriteLine($"will now take {l} steps in each direction");
                t = 0;
            }

            //do something in the direction
            switch (d % 4)
            {
                case 0:
                    {
                        index = index.AddVector(Vector2Int.left);
                        Console.WriteLine("moving left");
                        break;
                    }

                case 1:
                    {
                        index = index.AddVector(Vector2Int.up);
                        Console.WriteLine("moving up");
                        break;
                    }


                case 2:
                    {
                        index = index.AddVector(Vector2Int.right);
                        Console.WriteLine("moving right");
                        break;
                    }

                case 3:
                    {
                        index = index.AddVector(Vector2Int.down);
                        Console.WriteLine("moving down");
                        break;
                    }
                default:
                    break;
            }

            //count step taken
            s++;

            return index.x < enumerables.GetLength(0) && index.y < enumerables.GetLength(1);
        }

        public void Dispose() { }

        public void Reset() { }

    }
}
