using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Represents a base class for tiles to be used in a tile map.
    /// </summary>
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
            Hole // core engine mazochist
        }
        public State state = State.Empty;

        public void SetIndexer(Vector2Int index)
        {
            //we had a bug where these values were passed the wrong way and we couldnt figure it out, so this line is written the opposite now
            indexer = new(index.y, index.x);
        }

        public void SetTileState(State state)
        {
            this.state = state;
        }

        public void SetObjectToTile(TileObject to)
        {
            tileObject = to;
            state = State.Occupied;
        }

        public void PassedCallBack()
        {
            tileObject = null;
            state = State.Empty;
        }
    }
}
