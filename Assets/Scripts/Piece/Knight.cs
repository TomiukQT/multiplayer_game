using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knight : Piece
{
    public override List<Vector2Int> GetMovePositions()
    {
        var moves =  new List<Vector2Int>()
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
        return moves.FindAll(x => IsValid(x.x,x.y,out var enemy)).ToList();

    }
}
