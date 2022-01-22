using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override List<Vector2Int> GetMovePositions()
    {
        return new List<Vector2Int>()
        {
            _position + new Vector2Int(2, 1),
            _position + new Vector2Int(2, -1),
            _position + new Vector2Int(-2, -1),
            _position + new Vector2Int(-2, 1),
            _position + new Vector2Int(1, 2),
            _position + new Vector2Int(1, -2),
            _position + new Vector2Int(-1, -2),
            _position + new Vector2Int(-1, 2),
        };
    }
}
