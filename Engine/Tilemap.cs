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
        public Tilemap(Tile tileType, int rows, int cols)
        {
            Tile[,] grid = new Tile[rows, cols];
            TileInjector(rows, cols, grid);
        }

        public void TileInjector(int rows, int cols, Tile[,] grid)
        {
            int indexerValue = 1;
            Vector2 tilePos = new Vector2(30, 0);
            for (int i = 0; i < rows; i++)
            {
                tilePos = new Vector2(tilePos.x, tilePos.y + 30);

                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = new RectangleTile(tilePos);
                    grid[i, j].IndexerSetter(indexerValue);
                    indexerValue++;
                    tilePos = new Vector2(tilePos.x + 30, tilePos.y);
                    Log.InfoMessage($"A rectangle tile was injected at {grid[i, j]}.");
                }
            }
            Log.InfoMessage("The tile map finished configuring.");
        }

        public IEnumerator<Tile> GetEnumerator() => new TileMapEnumerator<Tile>();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }


    public struct TileMapEnumerator<T> : IEnumerator<T>
    {
        T[] enumerables;
        int index = -1;

        public TileMapEnumerator(T[] enumerables)
        {
            this.enumerables = enumerables;
        }

        public T Current => index < enumerables.Length && index >= 0 ? enumerables[index] : default(T);

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            index++;
            return index < enumerables.Length;
        }

        public void Reset() { }

        public void Dispose() { }
    }
}
