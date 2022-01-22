using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece
{
    public override List<Vector2Int> GetMovePositions()
    {
        var moves = new List<Vector2Int>();
        for (int i = _position.x + 1; i < Board.MAX_SIZE; i++)
            if (_board.GetPiece(i, _position.y) == null) moves.Add(_position + new Vector2Int(i, 0));
        for (int i = _position.x - 1; i >= 0; i--)
            if (_board.GetPiece(i, _position.y) == null) moves.Add(_position + new Vector2Int(-i, 0));
        for (int i = _position.y + 1; i < Board.MAX_SIZE; i++)
            if (_board.GetPiece(_position.x, i) == null) moves.Add(_position + new Vector2Int(0,i));
        for (int i = _position.y - 1; i >= 0; i--)
            if (_board.GetPiece(_position.x, i) == null) moves.Add(_position + new Vector2Int(0, -i));

        return moves;
    }
}
