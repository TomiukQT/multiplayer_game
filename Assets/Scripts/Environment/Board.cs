using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using JetBrains.Annotations;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Material _whiteMaterial;
    [SerializeField] private Material _blackMaterial;
   
    
    private Grid<Tile> _grid;
    [HideInInspector] public const int MAX_SIZE = 8;

    private List<Vector2Int> _highligtedTiles;
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

    }

    public void GeneratePieces(BoardLayout whiteLayout, BoardLayout blackLayout)
    {
        GenerateSingleLayout(whiteLayout,TeamColor.White,0,0,+1);
        GenerateSingleLayout(blackLayout,TeamColor.Black,MAX_SIZE-1,7,-1);
    }

    private void GenerateSingleLayout(BoardLayout layout,TeamColor color, int start,int row,int sign)
    {
        for (int i = 0; i < MAX_SIZE; i++)
        {
            var piece = Instantiate(layout.Back[i],
                GetPositionFromCoords((start+i*sign, row)), Quaternion.identity, transform).GetComponent<Piece>();
            var pawnPiece = Instantiate(layout.Front[i],
                GetPositionFromCoords((start+i*sign, row+1*sign)), Quaternion.identity, transform).GetComponent<Piece>();

            piece.GetComponent<MeshRenderer>().material = color == TeamColor.White ? _whiteMaterial : _blackMaterial;
            pawnPiece.GetComponent<MeshRenderer>().material = color == TeamColor.White ? _whiteMaterial : _blackMaterial;

            _grid.Get(start+i*sign, row).Piece = piece;
            _grid.Get(start+i*sign, row+1*sign).Piece = pawnPiece;
            
            piece.Setup(this,color,new Vector2Int(start+i*sign, row));
            pawnPiece.Setup(this,color,new Vector2Int(start+i*sign, row+1*sign));

        }
    }

    public bool MovePiece(Piece piece, Vector2Int from, Vector2Int to)
    {
        Debug.Log("Moving");
        if (!piece.GetMovePositions().Contains(to))
            return false;
        Debug.Log("MovingIn");
        var opponentPiece = _grid.Get(to.x, to.y).Piece;

        if (opponentPiece != null)
        {
            Destroy(opponentPiece.gameObject);
        }

        _grid.Get(to.x,to.y).Piece = piece;
        _grid.Get(from.x, from.y).Piece = null;

        piece.Position = to;
        piece.transform.position = GetPositionFromCoords(to);
        
        return true;
    }
    
    
    private void UnHighlightTiles()
    {
        if (_highligtedTiles == null)
            return;
        foreach (var tileCoord in _highligtedTiles)
            _grid.Get(tileCoord.x,tileCoord.y)?.MaterialChanger.SetHighlight(false);
    }
    
    
    public void SetHighlightOnTiles(List<Vector2Int> coords, bool toggle = true)
    {
        UnHighlightTiles();
        foreach (var tileCoord in coords)
            _grid.Get(tileCoord.x,tileCoord.y)?.MaterialChanger.SetHighlight(toggle);
        _highligtedTiles = coords;
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

    public Piece GetPiece(int x, int y) => _grid.Get(x, y)?.Piece;
}
