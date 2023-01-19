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
    public class Tilemap
    {
        public Tile[,] grid;
        public Tilemap(Tile tileType, int rows, int cols)
        {
            grid = new Tile[rows, cols];
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
    }
}
