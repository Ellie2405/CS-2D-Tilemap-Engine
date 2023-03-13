using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class TileObject : ICloneable
    {
        public string ID { get; protected set; }
        public enum Actor
        {
            Player1,
            Player2
        }
        //protected Actor actor;
        public Actor ObjectActor { get; protected set; }

        private List<Vector2> moves;

      //  public TileObject(int actorNum, string iD)
      //  {
      //      ID = iD;
      //      if (actorNum == 1) actor = Actor.Player1;
      //      else if (actorNum == 2) actor = Actor.Player2;
      //      Log.InfoMessage($"A new object was created - {actor}, ID : {ID}");
      //  }

        public void ObjectSetter(int actorNum, string iD)
        {
            ID = iD;
            if (actorNum == 1) ObjectActor = Actor.Player1;
            else if (actorNum == 2) ObjectActor = Actor.Player2;
            Log.InfoMessage($"A new object was created - {ObjectActor}, ID : {ID}");
        }

        public abstract void Move(Vector2 availableMove);

        public virtual void AddMove(Vector2 move)
        {
            moves.Add(move);
        }

        public virtual void AddMoves(List<Vector2> moveSet)
        {
            moves.AddRange(moveSet);
        }

        public virtual void PassedCallBack()
        {
            Log.RegularMessage($"{this.ID} had a tile object passed on it.");
        }

        public virtual void SteppedCallBack(Tile tile)
        {
            if(tile.tileObject == null) tile.TileObjectSetter(this);
            //else interact with current tile object
            Log.RegularMessage($"{this.ID} has stepped on a tile at index of {tile.indexer}");
        }

        public abstract object Clone();

        public void Fct()
        {
            //return an object
        }
    }
}
