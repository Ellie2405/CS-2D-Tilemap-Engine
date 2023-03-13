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
        TileObject _to = new TestObject2();

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
                if (item.tileObject != null)
                {
                    //would be nice to have actor as an integer
                    if (item.tileObject.ObjectActor == TileObject.Actor.Player1)
                        ObjectSigns[item.tileObject.GetType()].Print(ApplyDuoColor(item.indexer), 0);
                    else
                        ObjectSigns[item.tileObject.GetType()].Print(ApplyDuoColor(item.indexer), 1);
                }
                else TileRenderer.PrintEmpty(ApplyDuoColor(item.indexer));

                if (item.indexer.y == map.gridSize.y)
                    Console.WriteLine();
            }
        }

        void EnableDuoColor()
        {
            duoColorCount = 2;
        }

        int ApplyDuoColor(Vector2 index)
        {
            return (int)((index.x + index.y) % duoColorCount);
        }

        public override void Start()
        {

        }
    }

    class SomeObject : TileObject
    {
        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override void Move(Vector2 availableMove)
        {
            throw new NotImplementedException();
        }
    }
}
