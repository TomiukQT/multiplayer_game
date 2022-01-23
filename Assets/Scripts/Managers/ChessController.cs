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


    public TeamColor OnTurn => _onTurn;
    public bool IsRunning => _isRunning;
    
    
    [SerializeField] private Board _board;
    [SerializeField] private BoardLayout _initLayout;


    private void Awake()
    {
    }

    private void Start()
    {
        
        StartGame();
    }

    public void StartGame()
    {
        _board.GenerateBoard();
        _board.GeneratePieces(_initLayout,_initLayout);
        
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
