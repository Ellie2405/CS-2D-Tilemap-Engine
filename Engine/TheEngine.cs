using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    abstract class TheEngine
    {
        public Factory factory;

        public TheEngine()
        {
            factory = new Factory();
        }

        //public void SetTileObject(TileObject obj, Vector2 pos)
        //{
        //    obj.Position = pos;
        //}
    }

    class TestEngine : TheEngine
    {

    }
}
