using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Material _whiteMaterial;
    [SerializeField] private Material _blackMaterial;
    [SerializeField] private BoardLayout _initLayout;
    
    private Grid<Tile> _grid;
    private const int MAX_SIZE = 8;
    public void GenerateBoard()
    {
        int size = MAX_SIZE;
        _grid = new Grid<Tile>(size, size);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var tileObject = Instantiate(_tilePrefab,GetPositionFromCoords((i,j)),Quaternion.identity,transform);
                tileObject.GetComponent<MeshRenderer>().material = MaterialFromCoords((i, j));
                var tile = tileObject.GetComponent<Tile>();
                tile.Setup(new Vector2Int(i,j));
                _grid.Set(i,j,tile);
            }
        }
        if(_initLayout != null)
            GenerateLayout();
    }

    private void GenerateLayout()
    {
        //White
        for (int i = 0; i < MAX_SIZE; i++)
        {
            var piece = Instantiate(_initLayout.Back[i],
                GetPositionFromCoords((i, 0)), Quaternion.identity, transform).GetComponent<Piece>();
            var pawnPiece = Instantiate(_initLayout.Front[i],
                GetPositionFromCoords((i, 1)), Quaternion.identity, transform).GetComponent<Piece>();
            piece.GetComponent<MeshRenderer>().material = _whiteMaterial;
            pawnPiece.GetComponent<MeshRenderer>().material = _whiteMaterial;
            _grid.Get(i, 0).Piece = piece;
            _grid.Get(i, 1).Piece = pawnPiece;
        }

        //Black
        for (int i = 0; i < MAX_SIZE; i++)
        {
            var piece = Instantiate(_initLayout.Back[i],
                GetPositionFromCoords((MAX_SIZE-i-1, 7)), Quaternion.identity, transform).GetComponent<Piece>();
            var pawnPiece = Instantiate(_initLayout.Front[i],
                GetPositionFromCoords((MAX_SIZE-i-1, 6)), Quaternion.identity, transform).GetComponent<Piece>();
            piece.GetComponent<MeshRenderer>().material = _blackMaterial;
            pawnPiece.GetComponent<MeshRenderer>().material = _blackMaterial;
            _grid.Get(MAX_SIZE-i-1, 7).Piece = piece;
            _grid.Get(MAX_SIZE-i-1, 6).Piece = pawnPiece;
        }
        
    }

    public Vector3 GetPositionFromCoords(Vector2Int coords)
    {
        return new Vector3(coords.x,0,coords.y);
    }

    public Vector3 GetPositionFromCoords((int, int) coords) =>
        GetPositionFromCoords(new Vector2Int(coords.Item1, coords.Item2));

    private Material MaterialFromCoords((int, int) coords) =>
        (coords.Item1 + coords.Item2) % 2  == 0 ? _blackMaterial : _whiteMaterial;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + new Vector3(MAX_SIZE/2f,0,MAX_SIZE/2f),new Vector3(MAX_SIZE,.1f,MAX_SIZE));
    }
}
