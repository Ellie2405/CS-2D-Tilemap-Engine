using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class ConsoleRenderer : Renderer
    {
        List<TileRenderer> tileRenderers = new();
        

        public ConsoleRenderer()
        {
            NewTileRenderer();
        }

        void NewTileRenderer()
        {
            tileRenderers.Add(new TileRenderer());
        }

        public override void Render()
        {
            foreach (var item in tileRenderers)
            {
                item.PrintTile();
            }
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }
    }

}
