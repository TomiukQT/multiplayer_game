using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class InputHandler : MonoBehaviour, IInputHandler
{
     [SerializeField] private Vector3 _mousePosition = -Vector3.one;
     [SerializeField] private Vector3 _mousePositionUp = -Vector3.one;

     private Transform _selectedPiece;

     private ChessController _chessController;

     private void Awake()
     {
          _chessController = GameObject.Find("ChessController").GetComponent<ChessController>();
     }


     private void Update()
     {
          GetInput();   
          if(_selectedPiece != null)
               PieceAtMouse();
     }

     private void GetInput()
     {
          if (Input.GetMouseButtonDown(0))
          {
               _mousePosition = -Vector3.one;
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               if (Physics.Raycast(ray, out var hit))
               {
                    if (hit.collider.TryGetComponent<Piece>(out var piece))
                    {
                         _selectedPiece = piece.transform;
                         var position = piece.Position;
                         _mousePosition = hit.point;
                    }
               }
          }
          if (Input.GetMouseButtonUp(0))
          {
               if (_selectedPiece == null)
                    return;
               
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               if (Physics.Raycast(ray, out var hit))
               {
                    _mousePositionUp = hit.point;
                    //_chessController.GetInput(_selectedPiece,new Vector2Int());
               }
               
               _selectedPiece = null;
          }
     }

     private void PieceAtMouse()
     {
          
     }

     public Vector2Int GetSelectedTile()
     {
          return new Vector2Int(Mathf.RoundToInt(_mousePosition.x),Mathf.RoundToInt(_mousePosition.y));
     }
}
