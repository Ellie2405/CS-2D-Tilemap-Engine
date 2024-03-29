﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Engine
{
    internal class ConsoleRenderer : Renderer
    {
        Dictionary<Type, TileRenderer> ObjectSigns = new Dictionary<Type, TileRenderer>();
        List<TileRenderer> tileRenderers = new();

        int duoColorCount = 1;
        int largeTileSize = 3;
        bool renderLargeTiles = false;

        #region Constructors

        //render with defaul colors
        public ConsoleRenderer()
        {
            EnableDuoColor();
        }

        //render a monocolored board
        public ConsoleRenderer(ConsoleColor boardColor)
        {
            TileRenderer.SetBoardColor(boardColor);
        }

        //render custom actor colors with default board
        public ConsoleRenderer(ConsoleColor actorColor1, ConsoleColor actorColor2)
        {
            EnableDuoColor();
            TileRenderer.SetActorColor(actorColor1, actorColor2);
        }

        //render custom actor colors with monocolored board
        public ConsoleRenderer(ConsoleColor actorColor1, ConsoleColor actorColor2, ConsoleColor boardColor)
        {
            TileRenderer.SetActorColor(actorColor1, actorColor2);
            TileRenderer.SetBoardColor(boardColor);
        }

        //render custom actor colors and custom board colors
        public ConsoleRenderer(ConsoleColor actorColor1, ConsoleColor actorColor2, ConsoleColor boardColor1, ConsoleColor boardColor2)
        {
            EnableDuoColor();
            TileRenderer.SetActorColor(actorColor1, actorColor2);
            TileRenderer.SetBoardColor(boardColor1, boardColor2);
        }

        #endregion

        public override void NewObject(Type tileObjectType, char oSign)
        {
            tileRenderers.Add(new TileRenderer(oSign));
            ObjectSigns.Add(tileObjectType, tileRenderers.Last());
        }

        public override void NewObject(TileObject tileObject, char oSign)
        {
            tileRenderers.Add(new TileRenderer(oSign));
            ObjectSigns.Add(tileObject.GetType(), tileRenderers.Last());
        }

        public override void Render(Tilemap<RectangleTile> map)
        {
            //normal render logic
            if (!renderLargeTiles)
            {
                foreach (var item in map)
                {
                    if (item.indexer.Equals(TheEngine.indexer)) //check which tile is hovered over
                        EnableRenderSelection();
                    if (CheckHighlights(item)) //check if this tile needs to be highlighted
                        RenderHighlight(item);
                    else if (CheckMoveables(item))
                        RenderMaso(item);
                    else RenderTile(item);
                    if (item.indexer.x == map.gridSize.x)
                        Console.WriteLine();
                    DisableRenderSelection();
                }
            }
            //large tile render logic
            else
            {
                //render each tile n^2 times by rendering each tile n times and each row n times
                int tileIterator = 0; //iterates the tiles duh
                int heightIterator = 0; //iterates how many times each row completed render
                while (tileIterator < map.Count())
                {
                    for (int widthIterator = 0; widthIterator < largeTileSize; widthIterator++) //iterates width of the tile
                    {
                        RenderTile(map.grid[tileIterator % map.gridSize.x, tileIterator / map.gridSize.x]);
                    }
                    tileIterator++;
                    if (tileIterator % map.gridSize.x == 0) //if done rendering a 'pixel' row, start next row
                    {
                        Console.WriteLine();
                        heightIterator++;
                        if (heightIterator < largeTileSize) //if not done rendering the whole height of the row, render it again
                        {
                            tileIterator -= map.gridSize.x;
                        }
                        else heightIterator = 0;
                    }
                }
            }
            Console.WriteLine($"{TileRenderer.BoardColors[CheckersEngine.player1Turn.BoolToInt()]} turn");
        }

        void RenderTile(Tile tile)
        {
            if (tile.tileObject != null)
            {
                ObjectSigns[tile.tileObject.GetType()].Print(ApplyDuoColor(tile.indexer), (int)tile.tileObject.ObjectActor);
            }
            else TileRenderer.PrintEmpty(ApplyDuoColor(tile.indexer));
        }

        bool CheckHighlights(Tile tile)
        {
            foreach (var move in CheckersEngine.validPositions)
            {
                if (tile.indexer.Equals(move))
                {
                    return true;
                }
            }
            return false;
        }
        bool CheckMoveables(Tile tile)
        {
            foreach (var objPos in CheckersEngine.Moveables)
            {
                if (tile.indexer.Equals(objPos))
                {
                    return true;
                }
            }
            return false;
        }

        void RenderHighlight(Tile tile)
        {
            TileRenderer.PrintHightlight(ApplyDuoColor(tile.indexer));
        }

        void RenderMaso(Tile tile)
        {
            ObjectSigns[tile.tileObject.GetType()].PrintMaso(ApplyDuoColor(tile.indexer), (int)tile.tileObject.ObjectActor);

        }

        void EnableRenderSelection()
        {
            TileRenderer.SetBracketChars('[', ']');
        }

        void DisableRenderSelection()
        {
            TileRenderer.SetBracketChars(' ', ' ');
        }

        void EnableDuoColor()
        {
            duoColorCount = 2;
        }

        int ApplyDuoColor(Vector2Int index)
        {
            return (int)((index.x + index.y) % duoColorCount);
        }

        void EnableLargeTiles()
        {

        }

        public override void Start()
        {

        }
    }

}
