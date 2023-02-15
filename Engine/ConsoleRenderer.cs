using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class ConsoleRenderer : Renderer
    {
        Dictionary<TileObject, TileRenderer<TileObject>> tileObjects = new Dictionary<TileObject, TileRenderer<TileObject>>();
        List<TileRenderer<TileObject>> tileRenderers = new();
        RectangleTile[,] grid = new RectangleTile[8, 8];
        int index;
        //know the color of each team!!!!
        TileObject _to = new SomeObject("_to", 's', 1, new(1, 1));

        public ConsoleRenderer()
        {
            NewTileRenderer(_to);
        }

        void NewTileRenderer(TileObject tileObject)
        {
            tileObjects.Add(tileObject, new TileRenderer<TileObject>('$'));
            //tileRenderers.Add(new TileRenderer());
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }

        public override void Render(Tilemap<RectangleTile> map)
        {
            foreach (var item in map)
            {
                if (true)
                {
                    tileObjects[_to].Print();
                }
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
        public SomeObject(string name, char sign, int actorNum, Vector2 pos) : base(name, sign, actorNum, pos)
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
