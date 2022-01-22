using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    [SerializeField] protected TeamColor _teamColor;

    protected Vector2Int _position;
    
    protected Board _board;
    protected MaterialChanger _materialChanger;

    public void Awake()
    {
        _materialChanger = gameObject.AddComponent<MaterialChanger>();
    }

    public abstract List<Vector2Int> GetMovePositions();
    
    


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

    #endregion
    
}
