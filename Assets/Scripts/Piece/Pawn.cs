using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{

    public override List<Vector2Int> GetMovePositions()
    {
        return new List<Vector2Int>()
        {
            _position + new Vector2Int(1, 1),
            _position + new Vector2Int(0, 1),
            _position + new Vector2Int(-1, 1)
        };
    }
}
