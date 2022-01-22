using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private BoardLayout _initLayout;

    private ChessController _chessController;

    private void Awake()
    {
        _chessController = GameObject.Find("ChessController").GetComponent<ChessController>();
    }

    private void Start()
    {
        _board.GenerateBoard();
        _board.GeneratePieces(_initLayout,_initLayout);
        _chessController.StartGame(_board);
    }
    
    
}
