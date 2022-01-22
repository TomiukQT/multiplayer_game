using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class Pawn : Piece
{

    public override List<Vector2Int> GetMovePositions()
    {
        var moves = new List<Vector2Int>();
        int sign = _teamColor == TeamColor.White ? 1 : -1;

        if(_board.GetPiece(_position.x,_position.y + 1*sign) == null)
            moves.Add(_position + sign*new Vector2Int(0,1));
        if (!_moved && _board.GetPiece(_position.x,_position.y+sign*2) == null)
            moves.Add(_position + sign*new Vector2Int(0,2));
        if(IsValid(_position.x+1,_position.y+sign*1,out bool enemy) && enemy)
            moves.Add(_position + new Vector2Int(1,sign*1));
        if(IsValid(_position.x-1,_position.y+sign*1,out bool enemy2) && enemy2)
            moves.Add(_position + new Vector2Int(-1,sign*1));

        return moves;
    }
}
