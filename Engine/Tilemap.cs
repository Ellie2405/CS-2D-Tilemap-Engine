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
        public Tilemap(Tile tileType, int rows, int cols)
        {
            grid = new Tile[rows, cols];
            TileInjector(rows, cols, grid);
        }


        public void TileInjector(int rows, int cols, Tile[,] grid)
        {
            Vector2 tilePos = new Vector2(30, 0);
            for (int i = 0; i < rows; i++)
            {
                tilePos = new Vector2(tilePos.x, tilePos.y + 30);

                for (int j = 0; j < cols; j++)
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

        public bool MoveNext()
        {


            return index.x < enumerables.GetLength(0) && index.y < enumerables.GetLength(1);
        }




        public void Dispose() { }

        public void Reset() { }

    }
}
