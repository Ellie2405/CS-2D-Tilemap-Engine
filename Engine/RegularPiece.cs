using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class RegularPiece : TileObject
    {
        public RegularPiece()
        {
            AddMove("leftDiagonalUp", Vector2Int.leftDiagonalUp);
            AddMove("leftDiagonalDown", Vector2Int.leftDiagonalDown);
            AddMove("leftDiagonalUpEat", Vector2Int.leftDiagonalUpEat);
            AddMove("leftDiagonalDownEat", Vector2Int.leftDiagonalDownEat);
            AddMove("rightDiagonalUp", Vector2Int.rightDiagonalUp);
            AddMove("rightDiagonalDown", Vector2Int.rightDiagonalDown);
            AddMove("rightDiagonalUpEat", Vector2Int.rightDiagonalUpEat);
            AddMove("rightDiagonalDownEat", Vector2Int.rightDiagonalDownEat);
        }
        public override object Clone()
        {
            var item = new RegularPiece()
            {
                ObjectActor = ObjectActor,
                Position = Position,
                ID = ID,
                moves = moves
            };
            return item;
        }

    }
}
