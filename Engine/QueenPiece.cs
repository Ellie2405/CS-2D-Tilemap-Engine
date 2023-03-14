using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class QueenPiece : TileObject
    {
        public QueenPiece()
        {
            AddMove("rightDiagonalUp", Vector2Int.rightDiagonalUp);
            AddMove("rightDiagonalUp2", Vector2Int.rightDiagonalUp2);
            AddMove("rightDiagonalUp3", Vector2Int.rightDiagonalUp3);
            AddMove("rightDiagonalUp4", Vector2Int.rightDiagonalUp4);
            AddMove("rightDiagonalUp5", Vector2Int.rightDiagonalUp5);
            AddMove("rightDiagonalUp6", Vector2Int.rightDiagonalUp6);
            AddMove("rightDiagonalUp7", Vector2Int.rightDiagonalUp7);

            AddMove("rightDiagonalDown", Vector2Int.rightDiagonalDown);
            AddMove("rightDiagonalDown2", Vector2Int.rightDiagonalDown2);
            AddMove("rightDiagonalDown3", Vector2Int.rightDiagonalDown3);
            AddMove("rightDiagonalDown4", Vector2Int.rightDiagonalDown4);
            AddMove("rightDiagonalDown5", Vector2Int.rightDiagonalDown5);
            AddMove("rightDiagonalDown6", Vector2Int.rightDiagonalDown6);
            AddMove("rightDiagonalDown7", Vector2Int.rightDiagonalDown7);

            AddMove("leftDiagonalUp", Vector2Int.leftDiagonalUp);
            AddMove("leftDiagonalUp2", Vector2Int.leftDiagonalUp2);
            AddMove("leftDiagonalUp3", Vector2Int.leftDiagonalUp3);
            AddMove("leftDiagonalUp4", Vector2Int.leftDiagonalUp4);
            AddMove("leftDiagonalUp5", Vector2Int.leftDiagonalUp5);
            AddMove("leftDiagonalUp6", Vector2Int.leftDiagonalUp6);
            AddMove("leftDiagonalUp7", Vector2Int.leftDiagonalUp7);

            AddMove("leftDiagonalDown", Vector2Int.leftDiagonalDown);
            AddMove("leftDiagonalDown2", Vector2Int.leftDiagonalDown2);
            AddMove("leftDiagonalDown3", Vector2Int.leftDiagonalDown3);
            AddMove("leftDiagonalDown4", Vector2Int.leftDiagonalDown4);
            AddMove("leftDiagonalDown5", Vector2Int.leftDiagonalDown5);
            AddMove("leftDiagonalDown6", Vector2Int.leftDiagonalDown6);
            AddMove("leftDiagonalDown7", Vector2Int.leftDiagonalDown7);
        }

        public override object Clone()
        {
            var item = new QueenPiece()
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
