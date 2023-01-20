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
    public class Tilemap : IEnumerable<Tile>
    {
        public Tile[,] grid;
        //public Vector2 testStartPos = new Vector2(4, 4); // uncomment and insert in GetEnumerator() if you want to use the spiral enumerator
        public Vector2 gridSize = new Vector2(8, 8);
        public Tilemap(Tile tileType, Vector2 gridSize)
        {
            grid = new Tile[(int)gridSize.x, (int)gridSize.y];
            TileInjector(gridSize, grid);
            this.gridSize = gridSize;

            int value = 1;
            foreach (var item in grid)
            {
                item.IndexerSetter(value);
                value++;
            }
        }


        public void TileInjector(Vector2 gridSize, Tile[,] grid)
        {
            Vector2 tilePos = new Vector2(30, 0);
            for (int i = 0; i < gridSize.x; i++)
            {
                tilePos = new Vector2(tilePos.x, tilePos.y + 30);

                for (int j = 0; j < gridSize.y; j++)
                {
                    grid[i, j] = new RectangleTile(tilePos);
                    tilePos = new Vector2(tilePos.x + 30, tilePos.y);
                    Log.InfoMessage($"A rectangle tile was injected at {grid[i, j]}.");
                }
            }
            Log.InfoMessage("The tile map finished configuring.");
        }

        public Tile GetTile(Vector2 index)
        {
            return grid[(int)index.x, (int)index.y];
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
        Vector2 index = new Vector2(0, -1);
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
            if (index.y < enumerables.GetLength(1) - 1) index = new Vector2(index.x, index.y + 1);
            else if (index.y == enumerables.GetLength(1) - 1) index = new Vector2(index.x + 1, 0);

            return index.x < enumerables.GetLength(0) && index.y < enumerables.GetLength(1);
        }

        public void Dispose() { }

        public void Reset() { }
    }

    public struct SpiralEnumerator<Tile> : IEnumerator<Tile>
    {
        Vector2 index;
        Tile[,] enumerables;


        public SpiralEnumerator(Tile[,] enumerables, Vector2 index)
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
                        index = index.AddVector(Vector2.left);
                        Console.WriteLine("moving left");
                        break;
                    }

                case 1:
                    {
                        index = index.AddVector(Vector2.up);
                        Console.WriteLine("moving up");
                        break;
                    }


                case 2:
                    {
                        index = index.AddVector(Vector2.right);
                        Console.WriteLine("moving right");
                        break;
                    }

                case 3:
                    {
                        index = index.AddVector(Vector2.down);
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
