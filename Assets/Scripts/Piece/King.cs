using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{

    public override List<Vector2Int> GetMovePositions()
    {
        var moves = new List<Vector2Int>();
        int x = _position.x;
        int y = _position.y;
        for (int i = Mathf.Max(0,x-1); i < Mathf.Min(Board.MAX_SIZE-1,x+1); i++)
            for (int j = Mathf.Max(0,y-1); j < Mathf.Min(Board.MAX_SIZE-1,y+1); j++)
                if (_board.GetPiece(i, j) == null || _board.GetPiece(i, j).TeamColor != _teamColor) 
                    moves.Add(new Vector2Int(i, j));
        return moves;
    }
}
