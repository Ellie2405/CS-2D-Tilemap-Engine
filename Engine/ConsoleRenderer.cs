using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class ConsoleRenderer : Renderer
    {
        Dictionary<Type, TileRenderer> ObjectSigns = new Dictionary<Type, TileRenderer>();
        List<TileRenderer> tileRenderers = new();
        List<TileRenderer> tileRenderersTest = new();
        RectangleTile[,] grid = new RectangleTile[8, 8];

        //know the color of each team!!!!
        ConsoleColor team1TextColor;
        ConsoleColor team2TextColor;
        TileObject _to = new SomeObject(1);

        public ConsoleRenderer()
        {
            NewObject(_to.GetType(), '$');
        }

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
                    ObjectSigns[item.tileObject.GetType()].Print();
                }
                //1 for use, 2 for test
                else TileRenderer.PrintEmpty();
                //else ObjectSigns[_to.GetType()].Print();

                if (item.indexer.y+1 == map.gridSize.y)
                    Console.WriteLine();
            }
        }

        public override void Start()
        {
            foreach (var item in grid)
            {

            }
        }
    }

    class SomeObject : TileObject
    {
        public SomeObject(int actorNum) : base(actorNum)
        {

        }

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
