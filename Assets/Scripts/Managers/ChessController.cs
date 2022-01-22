using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Enums;
using UnityEngine;

public class ChessController : MonoBehaviour
{
    private TeamColor _onTurn = TeamColor.White;
    private bool _isRunning = false;
    private Board _board;


    public TeamColor OnTurn => _onTurn;
    public bool IsRunning => _isRunning;

    public void StartGame(Board board)
    {
        _isRunning = false;
        _onTurn = TeamColor.White;
    }
    
    public void GetInput(Piece piece, Vector2Int from, Vector2Int to)
    {
        if (!_isRunning || piece.TeamColor != _onTurn)
            return;
        if(_board.MovePiece(piece,from,to))
            NextTurn();
    }

    private void NextTurn() => _onTurn = _onTurn == TeamColor.White ? TeamColor.Black : TeamColor.White;


}
