using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class TestObject : TileObject
    {
        public TestObject(int actorNum, string iD) : base(actorNum, iD)
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
