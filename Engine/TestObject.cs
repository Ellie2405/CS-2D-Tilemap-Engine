using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class TestObject : TileObject
    {
      // public TestObject(int actorNum, string iD) : base(actorNum, iD)
      // {
      //     
      // }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override Vector2Int CalculateNewPosition(Vector2Int availableMove)
        {
            Position = Position.AddVector(availableMove);
            return Position;
        }
        // static public TestObject Sample() { return new TestObject(0,"0"); }

    }
}
