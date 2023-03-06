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
        public Vector2 indexer { get; protected set; } 
        public TileObject? tileObject { get; protected set; }
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
        public State state = State.Empty;

        //public Tile(Vector2 position)
        //{
        //    this.position = position;
        //}

        public void IndexerSetter(Vector2 index)
        {
            indexer = index;
        }

        public void TileObjectSetter(TileObject to)
        {
            tileObject = to;
            state = State.Occupied;
        }

        public void TileObjectRemover()
        {
            tileObject = null;
        }

    }
}
