using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{/// <summary>
/// Represents a base class for objects in the simulation.
/// </summary>
    public abstract class TileObject : ICloneable
    {
        public static Action<TileObject> onSteppedCallback;

        public Vector2Int Position { get; protected set; }


        public enum Actor
        {
            Player1,
            Player2
        }

        public Actor ObjectActor { get; protected set; }

        public Dictionary<string, Vector2Int> moves = new Dictionary<string, Vector2Int>();


        public virtual void ObjectSetter(int actorNum, Vector2Int position)
        {
            Position = position;
            if (actorNum == 1) ObjectActor = Actor.Player1;
            else if (actorNum == 2) ObjectActor = Actor.Player2;
        }

        public virtual Vector2Int CalculateNewPosition(Vector2Int availableMove)
        {
            return Position.AddVector(availableMove);
        }

        public void SetPosition(Vector2Int position)
        {
            Position = position;
        }

        public virtual void AddMove(string moveName, Vector2Int move)
        {
            moves.Add(moveName, move);
        }

        public virtual void SteppedCallBack(Tile tile) // set object and or change object to queen
        {

            if (tile.tileObject == null && tile.indexer.y == 8 || tile.tileObject == null && tile.indexer.y == 1)
            {
                onSteppedCallback?.Invoke(this);
                Console.WriteLine("invoked callback");
            }

            else if (tile.tileObject == null)
            {
                tile.SetObjectToTile(this);
            }

            else if (tile.tileObject != null)
            {
                Console.WriteLine("tile object isnt null");
            }

        }

        public abstract object Clone();

    }
}
