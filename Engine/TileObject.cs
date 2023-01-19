using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine_Final_Project
{
    public abstract class TileObject
    {
        public string Name { get; protected set; }
        public char Sign { get; protected set; }
        public Vector2 Position { get; protected set; }
        private enum Actor
        {
            Player1,
            Player2
        }
        private Actor actor;

        private List<Vector2> possibleMoves;
        private List<Vector2> availableMoves;

        public TileObject(string name, char sign, int actorNum, Vector2 pos)
        {
            Name = name;
            Sign = sign;
            Position = pos;
            if (actorNum == 1) actor = Actor.Player1;
            else if (actorNum == 2) actor = Actor.Player2;
            Log.InfoMessage($"A new object was created - {this.Name}, {this.Sign}, {this.Position}, {actor}");
        }

        public abstract void Move(Vector2 availableMove);




    }
}
