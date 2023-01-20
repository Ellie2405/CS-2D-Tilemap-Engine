using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Tile
    {
        public Vector2 position { get; protected set; }
        public Vector2 indexer { get; protected set; } // might be deleted
        public enum Actor
        {
            Player1,
            Player2
        }
        public Actor actor;

        public enum State
        {
            Empty,
            Occupied,
            Hole
        }
        public State state;

        //public Tile(Vector2 position)
        //{
        //    this.position = position;
        //}

        public void IndexerSetter(Vector2 index)
        {
            indexer = index;
        }

        public void PositionFactory(Vector2 pos)
        {
            position = pos;
        }
    }
}
