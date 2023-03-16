using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    abstract class TheEngine
    {
        public static Vector2Int indexer { get; protected set; } = new(4, 4);
        public abstract void Start();
        public abstract void GameLoop(Renderer renderer);
        public abstract void GetInput();
    }
}