using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{

    public override List<Vector2Int> GetMovePositions()
    {
        var moves = new List<Vector2Int>();
        var directions = new List<Vector2Int>()
        {
            new Vector2Int(1, 1), new Vector2Int(-1, 1), new Vector2Int(1, -1), new Vector2Int(-1, -1),
            new Vector2Int(1, 0), new Vector2Int(-1, 0), new Vector2Int(0, 1), new Vector2Int(0, -1)
        };
        foreach (var dir in directions)
        {
            for (Vector2Int pos = _position + dir; Utils.V2InRange(pos,0,Board.MAX_SIZE); pos += dir)
            {
                if (IsValid(pos.x,pos.y,out bool enemy)) 
                    moves.Add(new Vector2Int(pos.x,pos.y));
                else
                    break;
                if(enemy)
                    break;
            }
        }

        return moves;
    }
}
