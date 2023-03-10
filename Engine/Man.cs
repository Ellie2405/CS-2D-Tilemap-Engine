using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Engine.Tile;

namespace Engine
{
    internal class Man : TileObject
    {
        public override object Clone()
        {
            throw new NotImplementedException();
        }

        //public override object Clone()//string ID, int actorNum)
        //{
        //   // this.ID = ID;
        //   // if (actorNum == 1) actor = Actor.Player1;
        //   // else if (actorNum == 2) actor = Actor.Player2;
        //   //
        //   // return this;
        //}

        public override void Move(Vector2 availableMove)
        {
            throw new NotImplementedException();
        }
    }
}
