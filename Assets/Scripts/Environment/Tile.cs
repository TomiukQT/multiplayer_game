using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector2Int _coordinates;
    private Piece _piece;

    public MaterialChanger MaterialChanger;
    
    public void Setup(Vector2Int coords)
    {
        _coordinates = coords;
        MaterialChanger = gameObject.AddComponent<MaterialChanger>();
    }

    public void Setup((int, int) coords) =>
        Setup(new Vector2Int(coords.Item1, coords.Item2));
    
    

    [CanBeNull] public Piece Piece
    {
        get => _piece;
        set
        {
            if (_piece == null)
                _piece = value;
        }
    }
    
    private void OnMouseEnter()
    {
        //_piece?.OnMouseEnter();
    }
    
    private void OnMouseExit()
    {
        //_piece?.OnMouseExit();
    }

}
