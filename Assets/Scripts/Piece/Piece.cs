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
        enemy = _board.GetPiece(x, y) != null && TeamColor != _teamColor;
        return _board.GetPiece(x, y) == null || enemy;
    }


    #region Public Getters/Setters

    public TeamColor TeamColor => _teamColor;
    public void SetBoard(Board board) => _board = board;

    public void SetPosition(Vector2Int pos) => _position = pos;

    #endregion
    
    #region MouseEvents

    public void OnMouseEnter()
    {
        _materialChanger.SetHighlight(true);
        var validMoves = GetMovePositions();
        //Board ValidateMoves
        _board.SetHighlightOnTiles(validMoves);
    }

    public void OnMouseExit()
    {
        _materialChanger.SetHighlight(false);
    }

    public void OnMouseClick()
    {
        
    }

    #endregion
    
}
