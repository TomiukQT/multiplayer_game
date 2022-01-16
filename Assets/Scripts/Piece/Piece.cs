using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    [SerializeField] private TeamColor _teamColor;
    
    
    public abstract List<Vector2Int> GetMovePositions();


    #region Public Getters/Setters

    public TeamColor TeamColor => _teamColor;

    #endregion
    
}
