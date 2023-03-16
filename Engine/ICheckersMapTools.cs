using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Tools to control objects in a checkers map.
    /// </summary>
    public interface ICheckersMapTools
    {
        public abstract TileObject GetTileObjectByTileIndexer(Vector2Int index);

        public abstract bool CheckForTileObject(Vector2Int index);

        public abstract void RemoveObjectFromTile(Vector2Int index);

    }
}
