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
        public Vector2Int indexer { get; protected set; } 
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

        public void SetIndexer(Vector2Int index)
        {
            indexer = index;
        }

        public void SetObjectToTile(TileObject to) 
        {
            tileObject = to;
            state = State.Occupied;
        }

        public void RemoveObjectFromTile()
        {
            tileObject = null;
        }

        public void PassedCallBack() //eat
        {
            tileObject = null;
        }
    }
}
