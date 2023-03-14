using System;
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
            foreach (var item in map)
            {
                if (item.indexer.Equals(new Vector2Int(2, 3)))//selected?
                {
                    EnableRenderSelection();
                    RenderTile(item);
                    DisableRenderSelection();
                    continue;
                }
                RenderTile(item);
                if (item.indexer.x == map.gridSize.x)
                    Console.WriteLine();
            }
        }

        void RenderTile(Tile tile)
        {
            if (tile.tileObject != null)
            {
                //check if object belongs to player one
                if (tile.tileObject.ObjectActor == 0)
                    ObjectSigns[tile.tileObject.GetType()].Print(ApplyDuoColor(tile.indexer), 0);
                else
                    ObjectSigns[tile.tileObject.GetType()].Print(ApplyDuoColor(tile.indexer), 1);
            }
            else TileRenderer.PrintEmpty(ApplyDuoColor(tile.indexer));
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

        public override void Start()
        {

        }
    }

}
