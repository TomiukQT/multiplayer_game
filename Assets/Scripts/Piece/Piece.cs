using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    [SerializeField] protected TeamColor _teamColor;

    protected Vector2Int _position;
    protected bool _moved = false;
    
    protected Board _board;
    protected MaterialChanger _materialChanger;

    public void Awake()
    {
        _materialChanger = gameObject.AddComponent<MaterialChanger>();
    }

    public abstract List<Vector2Int> GetMovePositions();

    protected bool IsValid(int x, int y, out bool enemy)
    {
        var piece = _board.GetPiece(x, y);
        enemy = piece != null && piece.TeamColor != _teamColor;
        return piece == null || enemy;
    }


    #region Public Getters/Setters

    public void Setup(Board board, TeamColor color, Vector2Int pos)
    {
        _board = board;
        _teamColor = color;
        _position = pos;
    }
    
    public TeamColor TeamColor => _teamColor;
    public void SetBoard(Board board) => _board = board;

    public Vector2Int Position
    {
        get => _position;
        set
        {
            _moved = true;
            _position = value;
        } 
    }

    #endregion
    
    #region MouseEvents

    public void OnMouseEnter()
    {
        if(_)
        _materialChanger.SetHighlight(true);
        var validMoves = GetMovePositions();
        //Board ValidateMoves
        _board.SetHighlightOnTiles(validMoves);
        Debug.Log("MouseOn");
    }

    public void OnMouseExit()
    {
        _materialChanger.SetHighlight(false);
    }

    #endregion
    
}
